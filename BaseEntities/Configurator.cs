using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseEntities;
public static class Configurator
{
    public static void ConfigureServices<TUserAccount, TPersonProfile, TApplicationDbContext, TCommonDbContext>(this IServiceCollection services)
        where TPersonProfile : CommonPersonProfile<TPersonProfile, TUserAccount>
        where TUserAccount : CommonUserAccount<TUserAccount, TPersonProfile>
        where TApplicationDbContext : class, ICommonDbContext<TUserAccount, TPersonProfile>
        where TCommonDbContext : CommonDbContext<TUserAccount, TPersonProfile>, TApplicationDbContext
    {

        services.AddScoped<TApplicationDbContext>(provider => provider.GetService<TCommonDbContext>()!);
        services.AddScoped<ICommonDbContext<TUserAccount, TPersonProfile>>(provider => provider.GetService<TCommonDbContext>()!);

        services.AddDbContext<TCommonDbContext>(options =>
            options.UseSqlServer(@"Server=localhost;Database=Example;Trusted_Connection=True;MultipleActiveResultSets=true;encrypt=false;"));


        services.AddIdentity<TUserAccount, IdentityRole>()
            .AddEntityFrameworkStores<TCommonDbContext>()
            .AddDefaultTokenProviders();

    }
}
