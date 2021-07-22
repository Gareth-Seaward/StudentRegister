using Microsoft.Extensions.DependencyInjection;
using StudentRegisterApi.Behaviours;
using StudentRegisterApi.Behaviours.Interfaces;
using StudentRegisterApi.Models;
using StudentRegisterApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRegisterApi.Options
{
    public static class ModelServices
    {
        public static void AddModelServices(this IServiceCollection services)
        {
            services.AddScoped<StudentSevice>();
            services.AddScoped<CourseService>();
        }

        public static void AddModelServiceBehaviours(this IServiceCollection services)
        {
            services.AddTransient<IMongoCollectionBehaviour<Student>, MongoCollectionBehaviour<Student>>();
            services.AddTransient<IMongoCollectionBehaviour<Course>, MongoCollectionBehaviour<Course>>();
        }
    }
}
