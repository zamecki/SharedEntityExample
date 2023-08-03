using BaseEntities;
using Microsoft.AspNetCore.Mvc;

namespace WebExample.Controllers;
public class ExampleTestController : TestController<UserAccount, PersonProfile>
{
    public ExampleTestController(ICommonDbContext<UserAccount, PersonProfile> dbContext) : base(dbContext)
    {
    }
}
