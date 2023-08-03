// See https://aka.ms/new-console-template for more information
using BaseEntities;
using Microsoft.EntityFrameworkCore;



using var dbContext = new ExampleDbContext();
var result = dbContext.PeopleProfiles
                        .Include(t => t.UserAccount)
                            .ThenInclude(t => t.Employee)
                        .ToList();

public class PersonProfile : CommonPersonProfile
{
    public new UserAccount? UserAccount => (UserAccount?)base.UserAccount;
    public string? Message { get; set; }
}

public class UserAccount : CommonUserAccount
{
    public Guid? EmployeeId { get; set; }
    public virtual Employee? Employee { get; set; }
    public new virtual PersonProfile PersonProfile => (PersonProfile)base.PersonProfile;
}
public class Employee : IBaseEntity
{
    public Guid Id { get; set; }
    public string? EmployeeNumber { get; set; }
}

public class ExampleDbContext : CommonDbContext
{
    public new DbSet<UserAccount> UserAccounts { get; set; } = default!;
    public new DbSet<PersonProfile> PeopleProfiles { get; set; }
}




