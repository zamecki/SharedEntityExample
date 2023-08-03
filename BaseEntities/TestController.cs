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

    public TestController(ICommonDbContext<TUserAccount, TPersonProfile> dbContext)
    {
        this.dbContext = dbContext;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var t = dbContext.PeopleProfiles
         .Include(t => t.UserAccount).ToList();
        return Ok();
    }
}
