using Data;
using GraphQL;
#if !DEBUG
using Logger;
#endif
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Models;
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
builder.Services.AddScoped<TRepository<Factory, ApplicationDbContext>, FactoryRepository>();
builder.Services.AddScoped<TRepository<Container, ApplicationDbContext>, ContainerRepository>();
builder.Services.AddScoped<TRepository<be_semigura.Models.Location, ApplicationDbContext>, LocationRepository>();
builder.Services.AddScoped<TRepository<Lot, ApplicationDbContext>, LotRepository>();
builder.Services.AddScoped<TRepository<LotContainer, ApplicationDbContext>, LotContainerRepository>();
builder.Services.AddScoped<TRepository<LotContainerTerminal, ApplicationDbContext>, LotContainerTerminalRepository>();
builder.Services.AddScoped<TRepository<Terminal, ApplicationDbContext>, TerminalRepository>();
builder.Services.AddScoped<TRepository<SensorData, ApplicationDbContext>, SensorDataRepository>();
builder.Services.AddScoped<TRepository<Material, ApplicationDbContext>, MaterialRepository>();

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
    .AddType<TQueryTypeExtension<Factory>>()
    .AddType<TQueryTypeExtension<Container>>()
    .AddType<TQueryTypeExtension<be_semigura.Models.Location>>()
    .AddType<TQueryTypeExtension<Lot>>()
    .AddType<TQueryTypeExtension<LotContainer>>()
    .AddType<TQueryTypeExtension<LotContainerTerminal>>()
    .AddType<TQueryTypeExtension<Terminal>>()
    .AddType<TQueryTypeExtension<SensorData>>()
    .AddType<TQueryTypeExtension<Material>>()
    .AddMutationType<Mutation>()
     .AddType<TMutateTypeExtension<Factory>>()
     .AddType<TMutateTypeExtension<Container>>()
     .AddType<TMutateTypeExtension<be_semigura.Models.Location>>()
     .AddType<TMutateTypeExtension<Lot>>()
     .AddType<TMutateTypeExtension<LotContainer>>()
     .AddType<TMutateTypeExtension<LotContainerTerminal>>()
     .AddType<TMutateTypeExtension<Terminal>>()
     .AddType<TMutateTypeExtension<SensorData>>()
     .AddType<TMutateTypeExtension<Material>>()
    .AddSubscriptionType<Subscription>()
    .AddTypeExtension<TSubscriptionTypeExtension<Factory>>()
    .AddTypeExtension<TSubscriptionTypeExtension<Container>>()
    .AddTypeExtension<TSubscriptionTypeExtension<be_semigura.Models.Location>>()
    .AddTypeExtension<TSubscriptionTypeExtension<Lot>>()
    .AddTypeExtension<TSubscriptionTypeExtension<LotContainer>>()
    .AddTypeExtension<TSubscriptionTypeExtension<LotContainerTerminal>>()
    .AddTypeExtension<TSubscriptionTypeExtension<Terminal>>()
    .AddTypeExtension<TSubscriptionTypeExtension<SensorData>>()
    .AddTypeExtension<TSubscriptionTypeExtension<Material>>()
    ;

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
    });


var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors(MyAllowSpecificOrigins);
app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.MapGraphQL("/graphql");

app.Run();
