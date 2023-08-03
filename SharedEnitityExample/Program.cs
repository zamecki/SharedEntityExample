// See https://aka.ms/new-console-template for more information
using BaseEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
Configurator.ConfigureServices<ExampleDbContext>(services);
var serviceProvider = services.BuildServiceProvider();
var dbContext = serviceProvider.GetRequiredService<IExampleDbContext>();
var result = dbContext.PeopleProfiles
                        .Include(t => t.UserAccount)
                            .ThenInclude(t => ((UserAccount)t).Employee)
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

public interface IExampleDbContext : ICommonDbContext
{
    public new DbSet<UserAccount> UserAccounts { get; }
    public new DbSet<PersonProfile> PeopleProfiles { get; }
    public DbSet<Employee> Employees { get; }
}

public class ExampleDbContext : CommonDbContext, IExampleDbContext
{
    public ExampleDbContext(DbContextOptions options) : base(options)
    {
    }

    public new DbSet<UserAccount> UserAccounts { get; set; } = default!;
    public new DbSet<PersonProfile> PeopleProfiles { get; set; }
    public DbSet<Employee> Employees { get; set; }

}




