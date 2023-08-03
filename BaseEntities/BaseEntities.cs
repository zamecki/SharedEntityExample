using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BaseEntities;
public interface IBaseEntity
{
    public string Id { get; }
}
public abstract class CommonPersonProfile<TPersonProfile, TUserAccount>: IBaseEntity
        where TPersonProfile : CommonPersonProfile<TPersonProfile, TUserAccount>
        where TUserAccount : CommonUserAccount<TUserAccount, TPersonProfile>
{
    public string Id { get; set; }
    public string? UserAccountId { get; set; }
    public virtual TUserAccount? UserAccount  { get; protected set; } = default!;
}


public abstract class CommonUserAccount<TUserAccount, TPersonProfile> : IdentityUser, IBaseEntity
    where TPersonProfile : CommonPersonProfile<TPersonProfile, TUserAccount>
    where TUserAccount : CommonUserAccount<TUserAccount, TPersonProfile>
{
    public virtual TPersonProfile PersonProfile { get; protected set; } = default!;
}

public interface ICommonDbContext<TUserAccount, TPersonProfile>
    where TUserAccount : CommonUserAccount<TUserAccount, TPersonProfile>
    where TPersonProfile : CommonPersonProfile<TPersonProfile, TUserAccount>
{
    public DbSet<TUserAccount> UserAccounts { get; }
    public DbSet<TPersonProfile> PeopleProfiles { get; }
}
public class CommonDbContext<TUserAccount, TPersonProfile> : IdentityDbContext<TUserAccount>, ICommonDbContext<TUserAccount, TPersonProfile>
    where TUserAccount : CommonUserAccount<TUserAccount, TPersonProfile>
    where TPersonProfile : CommonPersonProfile<TPersonProfile, TUserAccount>
{
    public DbSet<TUserAccount> UserAccounts => base.Users;
    public DbSet<TPersonProfile> PeopleProfiles { get; set; }

    public CommonDbContext(DbContextOptions options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);        
    }
}