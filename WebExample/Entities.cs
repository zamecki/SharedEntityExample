
using BaseEntities;
using Microsoft.EntityFrameworkCore;

public class PersonProfile : CommonPersonProfile<PersonProfile, UserAccount>
{
    public string? Message { get; set; }
}

public class UserAccount : CommonUserAccount<UserAccount, PersonProfile>
{
    public string? EmployeeId { get; set; }
    public Employee? Employee { get; set; }
}
public class Employee : IBaseEntity
{
    public string Id { get; set; }
    public string? EmployeeNumber { get; set; }
}

public interface IExampleDbContext : ICommonDbContext<UserAccount, PersonProfile>
{
    public DbSet<Employee> Employees { get; }
}

public class ExampleDbContext : CommonDbContext<UserAccount, PersonProfile>, IExampleDbContext
{
    public ExampleDbContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Employee> Employees { get; set; }

}