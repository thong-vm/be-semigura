using Data;
using Logger;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using System.Text.Json;
namespace Controllers;


[Route("/api/[controller]")]
[ApiController]
[Authorize]
public class CommandsController : ControllerBase
{
    private readonly IConfiguration _config;
    private readonly LogFormater _log;
    private readonly ApplicationDbContext _db;

    public CommandsController(
        IConfiguration config,
        ILogger<CommandsController> logger,
        ApplicationDbContext db
        )
    {
        _config = config;
        _log = new LogFormater(logger);
        _db = db;
    }

    public class Command
    {
        public string? Name { get; set; } = "";
        public string? Data { get; set; } = "";
    }

    class BackupData
    {
        public List<Truck>? Trucks { get; set; }
        public List<Delivery>? Deliverys { get; set; }
        public List<Area>? Areas { get; set; }
        public List<Product>? Products { get; set; }
    }

    // POST: api/commands
    [HttpPost]
    public ActionResult Post(Command command)
    {
        try
        {
            switch (command.Name)
            {
                case "clean":
                    {
                        if (command.Data == null)
                        {
                            throw new Exception("Invalid data");
                        }
                        List<DateTimeOffset> days = JsonSerializer.Deserialize<List<DateTimeOffset>>(command.Data) ?? throw new Exception("Invalid data");
                        //var ret = new List<Models.Task>();
                        //days.ForEach(day => ret.AddRange(CleanData(day)));
                        return Ok(null);
                    }
                case "newid":
                    return base.Ok(Models.ModelsHelper.NewId());
                case "parseid":
                    {
                        if (string.IsNullOrEmpty(command.Data)) { throw new Exception("id is null!"); }
                        return base.Ok(Models.ModelsHelper.ParseId(command.Data));
                    }

                case "backup":
                    {
                        var trucks = _db.Set<Truck>().ToList();
                        var deliverys = _db.Set<Delivery>().ToList();
                        var areas = _db.Set<Area>().ToList();
                        var products = _db.Set<Product>().ToList();
                        var data = new BackupData { Trucks = trucks, Deliverys = deliverys, Areas = areas, Products = products };
                        return Ok(data);
                    }
                case "restore":
                    {
                        var data = command.Data?.FromJson<BackupData>() ?? throw new Exception("Json data error!");
                        if (data.Trucks!=null)
                        {
                            var trucks = _db.Set<Truck>().Select(x => x.Id).ToList();
                            _db.Set<Truck>().AddRange(data.Trucks.Where(t => !trucks.Contains(t.Id)));
                        }
                        
                        if (data.Deliverys!=null) {
                            var deliverys = _db.Set<Delivery>().Select(x=>x.Id).ToList();
                            _db.Set<Delivery>().AddRange(data.Deliverys.Where(t => !deliverys.Contains(t.Id)));
                        }

                        if (data.Areas != null)
                        {
                            var areas = _db.Set<Area>().Select(x=>x.Id).ToList();
                            _db.Set<Area>().AddRange(data.Areas.Where(t => !areas.Contains(t.Id)));
                        }

                        if (data.Products != null)
                        {
                            var products = _db.Set<Product>().Select(x => x.Id).ToList();
                            _db.Set<Product>().AddRange(data.Products.Where(t => !products.Contains(t.Id)));
                        }

                        _db.SaveChanges();
                        return base.Ok();
                    }
            }
            return BadRequest("Invalid command");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

}

public static class DateExtentions
{
    public static DateTimeOffset StartOfDay(this DateTimeOffset dateTime)
    {
        return new DateTimeOffset(dateTime.Year, dateTime.Month, dateTime.Day, 0, 0, 0, 0, dateTime.Offset);
    }

    public static DateTimeOffset EndOfDay(this DateTimeOffset dateTime)
    {
        return dateTime.StartOfDay().AddDays(1);
    }

    public static DateTimeOffset StartOfMonth(this DateTimeOffset dateTime)
    {
        return new DateTimeOffset(dateTime.Year, dateTime.Month, 1, 0, 0, 0, 0, dateTime.Offset);
    }

    public static DateTimeOffset EndOfMonth(this DateTimeOffset dateTime)
    {
        return dateTime.StartOfMonth().AddMonths(1);
    }

    public static DateTimeOffset StartOfYear(this DateTimeOffset dateTime)
    {
        return new DateTimeOffset(dateTime.Year, 1, 1, 0, 0, 0, 0, dateTime.Offset);
    }

    public static DateTimeOffset EndOfYear(this DateTimeOffset dateTime)
    {
        return dateTime.StartOfYear().AddYears(1);
    }
}

