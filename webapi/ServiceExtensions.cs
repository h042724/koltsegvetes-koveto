using Microsoft.AspNetCore.Identity;
using webapi.Context;
using webapi.Models;

namespace webapi
{
    public static class ServiceExtensions
    {

        public static void ConfigureIdentity(this IServiceCollection services)
        {
            var builder = services.AddIdentityCore<ApiUser>(q => q.User.RequireUniqueEmail = true);

            builder = new IdentityBuilder(builder.UserType, typeof(IdentityRole), builder.Services);
            builder.AddEntityFrameworkStores<EFContext>().AddDefaultTokenProviders();

        }
    }
}
