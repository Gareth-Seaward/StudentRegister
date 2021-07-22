using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using StudentRegisterApi.Models;
using StudentRegisterApi.Models.Interfaces;
using System;

namespace StudentRegisterApi.Options
{
    public static class SchoolDatabaseOptions
    {
        public static void ConfigureSchoolDatabaseOptions(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<SchoolDatabaseSettings>(config.GetSection(nameof(SchoolDatabaseSettings)));

            services.AddSingleton<ISchoolsDatabaseSettings>(provider =>
                provider.GetRequiredService<IOptions<SchoolDatabaseSettings>>().Value);
        }

    }
}
