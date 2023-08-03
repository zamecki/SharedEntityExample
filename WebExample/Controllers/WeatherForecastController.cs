using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebExample.Controllers;
[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IExampleDbContext dbContext;
    private readonly UserManager<UserAccount> userManager;
    private readonly SignInManager<UserAccount> signInManager;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, IExampleDbContext dbContext, UserManager<UserAccount> userManager, SignInManager<UserAccount> signInManager)
    {
        _logger = logger;
        this.dbContext = dbContext;
        this.userManager = userManager;
        this.signInManager = signInManager;
    }

    [HttpGet]
    public IActionResult Get()
    {
        //(dbContext as DbContext).Database.Migrate();
        var t = dbContext.PeopleProfiles
         .Include(t => t.UserAccount)
           .ThenInclude(t => t.Employee).ToList();
        
        return Ok();
    }
}
