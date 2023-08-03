using BaseEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebExample.Controllers;
public class ExampleTestController : TestController<UserAccount, PersonProfile>
{
    public ExampleTestController(ICommonDbContext<UserAccount, PersonProfile> dbContext, UserManager<UserAccount> userManager, SignInManager<UserAccount> signInManager) : base(dbContext, userManager, signInManager)
    {
    }
}
