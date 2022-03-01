using OZ.Interfaces;
using OZ.Maps;
using OZ.Models.Context;
using OZ.Repositories;
using OZ.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OZ.API
{
    public class DependencyInjectionConfig
    {
        public static void AddScope(IServiceCollection services)
        {
            //services.AddScoped<IApplicationContext, ApplicationContext>();
            services.AddScoped<IAddictMap, AddictMap>();
            services.AddScoped<IAddictService, AddictService>();
            services.AddScoped<IAddictRepository, AddictRepository>();

            services.AddScoped<IAddictDrugsMap, AddictDrugsMap>();
            services.AddScoped<IAddictDrugsService, AddictDrugsService>();
            services.AddScoped<IAddictDrugsRepository, AddictDrugsRepository>();

            services.AddScoped<IAddictRelationsMap, AddictRelationsMap>();
            services.AddScoped<IAddictRelationsService, AddictRelationsService>();
            services.AddScoped<IAddictRelationsRepository, AddictRelationsRepository>();

            services.AddScoped<IAddictManagePlaceMap, AddictManagePlaceMap>();
            services.AddScoped<IAddictManagePlaceService, AddictManagePlaceService>();
            services.AddScoped<IAddictManagePlaceRepository, AddictManagePlaceRepository>();

            services.AddScoped<IAddictVehicleMap, AddictVehicleMap>();
            services.AddScoped<IAddictVehicleService, AddictVehicleService>();
            services.AddScoped<IAddictVehicleRepository, AddictVehicleRepository>();


            services.AddScoped<IAddictClassifyMap, AddictClassifyMap>();
            services.AddScoped<IAddictClassifyService, AddictClassifyService>();
            services.AddScoped<IAddictClassifyRepository, AddictClassifyRepository>();

            services.AddScoped<IClassifyMap, ClassifyMap>();
            services.AddScoped<IClassifyService, ClassifyService>();
            services.AddScoped<IClassifyRepository, ClassifyRepository>();

            services.AddScoped<IDrugsMap, DrugsMap>();
            services.AddScoped<IDrugsService, DrugsService>();
            services.AddScoped<IDrugsRepository, DrugsRepository>();

            services.AddScoped<IRelationsMap, RelationsMap>();
            services.AddScoped<IRelationsService, RelationsService>();
            services.AddScoped<IRelationsRepository, RelationsRepository>();

            services.AddScoped<IEducationLevelMap, EducationLevelMap>();
            services.AddScoped<IEducationLevelService, EducationLevelService>();
            services.AddScoped<IEducationLevelRepository, EducationLevelRepository>();

            services.AddScoped<IManagePlaceMap, ManagePlaceMap>();
            services.AddScoped<IManagePlaceService, ManagePlaceService>();
            services.AddScoped<IManagePlaceRepository, ManagePlaceRepository>();

            services.AddScoped<IManageCityMap, ManageCityMap>();
            services.AddScoped<IManageCityService, ManageCityService>();
            services.AddScoped<IManageCityRepository, ManageCityRepository>();

            services.AddScoped<IUsesMap, UsesMap>();
            services.AddScoped<IUsesService, UsesService>();
            services.AddScoped<IUsesRepository, UsesRepository>();

            services.AddScoped<IUserMap, UserMap>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IProvinceMap, ProvinceMap>();
            services.AddScoped<IProvinceService, ProvinceService>();
            services.AddScoped<IProvinceRepository, ProvinceRepository>();

            services.AddScoped<IDashboardMap, DashboardMap>();
            services.AddScoped<IDashService, DashService>();
            services.AddScoped<IDashRepository, DashRepository>();
        }
    }
}
