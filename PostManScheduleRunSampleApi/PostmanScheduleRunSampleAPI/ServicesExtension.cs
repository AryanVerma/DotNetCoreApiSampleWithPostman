using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using PostmanScheduleRunSampleAPI.DatabaseContext;
using PostmanScheduleRunSampleAPI.Helper;
using PostmanScheduleRunSampleAPI.Services;
using Swashbuckle.AspNetCore.Filters;
using System.Reflection;

namespace PostmanScheduleRunSampleAPI
{

    public static class ServicesExtension
    {
        public static void RegisterDBContext(this IServiceCollection service)
        {
            _ = service.AddDbContext<UsersDatabaseContext>(options =>
            {
                options.UseMySql(ConfigurationHelper.MysqlDbConnectionString, ServerVersion.AutoDetect(ConfigurationHelper.MysqlDbConnectionString));
            }).AddEntityFrameworkMySql();
            service.AddScoped<DbContext, UsersDatabaseContext>();
        }
        public static void RegisterRepos(this IServiceCollection service)
        {
           
            service.AddScoped<IUsersService, UsersService>();
            service.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        }
    }
}