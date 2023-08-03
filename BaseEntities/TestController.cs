using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BaseEntities;
[ApiController]
[Route("[controller]")]
public class TestController<TUserAccount, TPersonProfile> : ControllerBase
    where TPersonProfile : CommonPersonProfile<TPersonProfile, TUserAccount>
    where TUserAccount : CommonUserAccount<TUserAccount, TPersonProfile>
{
    private readonly ICommonDbContext<TUserAccount, TPersonProfile> dbContext;
    private readonly UserManager<TUserAccount> userManager;
    private readonly SignInManager<TUserAccount> signInManager;

    public TestController(ICommonDbContext<TUserAccount, TPersonProfile> dbContext, UserManager<TUserAccount> userManager, SignInManager<TUserAccount> signInManager)
    {
        this.dbContext = dbContext;
        this.userManager = userManager;
        this.signInManager = signInManager;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var t = dbContext.PeopleProfiles
         .Include(t => t.UserAccount).ToList();
        return Ok();
    }
}
