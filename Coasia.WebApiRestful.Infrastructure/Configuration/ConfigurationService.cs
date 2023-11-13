using Coasia.WebApiRestful.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Coasia.WebApiRestful.Infrastructure.Configuration
{
    public static class ConfigurationService
    {
        public static void RigisterContextDb(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<NetCoreDbcontext>(options => options.UseSqlServer(configuration.GetConnectionString("NetWebApiConnection"), options => options.MigrationsAssembly(typeof(NetCoreDbcontext).Assembly.FullName)));
        }
    }
}
