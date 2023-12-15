using be_semigura.Models;
using be_semigura.Repositories;
using Data;
using GraphQL;
#if !DEBUG
using Logger;
#endif
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Models;
using Newtonsoft.Json;
using Repositories;
using System.Text;
using System.Text.Json.Serialization;
using Template;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

// Add services to the container.

builder.Services.AddControllersWithViews();
#if !DEBUG
builder.Host.ConfigureLogging((hostContext, logBuilder) =>
        logBuilder.ClearProviders()
            .AddFileLogger(configuration =>
            {
                hostContext.Configuration.GetSection("Logging").GetSection("RoundTheCodeFile").GetSection("Options").Bind(configuration);
            }));
#endif
builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.Limits.MaxRequestBodySize = long.MaxValue;
});

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(option =>
{
#if DEBUG
    var usedCnn = builder.Configuration["UsedConnectionString_Debug"];
#else
    var usedCnn = builder.Configuration["UsedConnectionString"];
#endif
    if (usedCnn == "PSQLDB")
    {
        option.UseNpgsql(builder.Configuration.GetConnectionString(usedCnn));
    }
    else
    {
        option.UseSqlServer(builder.Configuration.GetConnectionString(usedCnn));
    }
});

// CORS
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    //options.AddPolicy(MyAllowSpecificOrigins,
    //   policy =>
    //   {
    //       policy.WithOrigins("https://localhost:8080", "https://localhost:3000")
    //       .WithMethods("PUT", "DELETE", "GET");
    //   });

    options.AddPolicy(MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("*")
                            .WithHeaders("*")
                            .WithMethods("*");
                      });
});

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters =
            new TokenValidationParameters
            {
                ValidIssuer = builder.Configuration["Jwt:Issuer"],
                ValidAudience = builder.Configuration["Jwt:Audience"],
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
            };
    });

// add repositories
builder.Services.AddScoped<TRepository<User, ApplicationDbContext>, UserRepository>();
builder.Services.AddScoped<TRepository<Moromi, ApplicationDbContext>, MoromiRepository>();
builder.Services.AddScoped<TRepository<Batch, ApplicationDbContext>, BatchRepository>();

// add graphQL
builder.Services.AddGraphQLServer()
    .AddAuthorization()
    .AddTypeExtension<UserExtensions>()
    .AddProjections()
    .AddFiltering()
    .AddSorting()
    .AddType<UploadType>()
    .AddInMemorySubscriptions()
    .AddQueryType<Query>()
    .AddType<TQueryTypeExtension<Moromi>>()
    .AddMutationType<Mutation>()
     .AddType<TMutateTypeExtension<Moromi>>()
    .AddSubscriptionType<Subscription>()
    .AddTypeExtension<TSubscriptionTypeExtension<Moromi>>()
    ;

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
    });


var app = builder.Build();

// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors(MyAllowSpecificOrigins);
app.UseAuthentication();
app.UseAuthorization();


//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller}/{action=Index}/{id?}");

app.MapControllers();

app.MapGraphQL("/graphql");

//app.MapFallbackToFile("index.html"); ;

app.Run();
