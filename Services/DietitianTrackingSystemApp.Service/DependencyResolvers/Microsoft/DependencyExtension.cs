using DietitianTrackingSystemApp.Data.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietitianTrackingSystemApp.Service.DependencyResolvers.Microsoft
{
    public static class DependencyExtension
    {
        public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DietitianTrackingSystemDbContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("Local"));
            });
        }
    }
}
