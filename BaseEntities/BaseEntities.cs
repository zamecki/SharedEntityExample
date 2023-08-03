using Microsoft.EntityFrameworkCore;

namespace BaseEntities;
public interface IBaseEntity
{
    public Guid Id { get; }
}
public abstract class CommonPersonProfile : IBaseEntity
{
    public Guid Id { get; set; }
    public Guid? UserAccountId { get; set; }
    public virtual CommonUserAccount UserAccount  { get; protected set; } = default!;
}


public abstract class CommonUserAccount : IBaseEntity
{
    public Guid Id { get; set; }
    public virtual CommonPersonProfile PersonProfile { get; protected set; } = default!;
}


public class CommonDbContext : DbContext
{
    public DbSet<CommonUserAccount> UserAccounts { get; set; }
    public DbSet<CommonPersonProfile> PeopleProfiles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=localhost;Database=Example;Trusted_Connection=True;MultipleActiveResultSets=true;encrypt=false;");
    }
}