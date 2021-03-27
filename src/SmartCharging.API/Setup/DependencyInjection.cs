using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SmartCharging.Application.Queries;
using SmartCharging.Infrastructure;
using SmartCharging.Setup.Infrastructure;

namespace SmartCharging.Api.Setup
{
    public static class DependencyInjection
    {
        public static void InjetcDataBase(IServiceCollection services, IConfiguration configuration)
        {         
            SetGroupStationDataBase(services, configuration);
        }      

        private static void SetGroupStationDataBase(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<GroupStationDatabaseSettings>(configuration.GetSection(nameof(GroupStationDatabaseSettings)));

            services.AddSingleton<IGroupStationDatabaseSettings>(sp => sp.GetRequiredService<IOptions<GroupStationDatabaseSettings>>().Value);

            services.AddScoped<IGroupRepository, GroupRepository>();
        }
    }
}
