using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BaseEntities;
public interface IBaseEntity
{
    public string Id { get; }
}
public abstract class CommonPersonProfile : IBaseEntity
{
    public string Id { get; set; }
    public string? CommonUserAccountId { get; set; }
    public virtual CommonUserAccount? CommonUserAccount  { get; protected set; } = default!;
}


public abstract class CommonUserAccount : IdentityUser, IBaseEntity
{
    public virtual CommonPersonProfile CommonPersonProfile { get; protected set; } = default!;
}


public class CommonDbContext : IdentityDbContext<CommonUserAccount>
{
    public DbSet<CommonUserAccount> UserAccounts => base.Users;
    public DbSet<CommonPersonProfile> PeopleProfiles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=localhost;Database=Example;Trusted_Connection=True;MultipleActiveResultSets=true;encrypt=false;");
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);        
    }
}