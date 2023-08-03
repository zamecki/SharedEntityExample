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
    public UserAccount? UserAccount => (UserAccount?)base.CommonUserAccount;
    public string? Message { get; set; }
}

public class UserAccount : CommonUserAccount
{
    public string? EmployeeId { get; set; }
    public Employee? Employee { get; set; }
    public PersonProfile PersonProfile => (PersonProfile)base.CommonPersonProfile;
}
public class Employee : IBaseEntity
{
    public string Id { get; set; }
    public string? EmployeeNumber { get; set; }
}

public class ExampleDbContext : CommonDbContext
{
    public new DbSet<UserAccount> UserAccounts { get; set; } = default!;
    public new DbSet<PersonProfile> PeopleProfiles { get; set; }
}




