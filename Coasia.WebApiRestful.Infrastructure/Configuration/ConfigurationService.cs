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
    // Khởi tạo các phương thức Extention method cho các Class có sẵn để dễ dàng thực hiện gọi phương thức bổ xung.
    public static class ConfigurationService
    {
        // Add Dbcontext tự động gọi đến chuỗi connectstring trong thư mục Coasia.WebApiRestful
        public static void RigisterContextDb(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<NetCoreDbcontext>(options => options.UseSqlServer(configuration.GetConnectionString("NetWebApiConnection"),
                                    options => options.MigrationsAssembly(typeof(NetCoreDbcontext).Assembly.FullName)));
        }

        public static void Test(this IServiceCollection services, IConfiguration configuration)
        {
            Console.WriteLine("no name");
        }
    }
}
