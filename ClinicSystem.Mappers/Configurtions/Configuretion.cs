﻿
using ClinicSystem.BLL.Services;
using ClinicSystem.BOL.IRepositories;
using ClinicSystem.BOL.IServices;
using ClinicSystem.Repositories.Repostories;
using ClinicSystem.Repository;
using ClinicSystem.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.Helpers.Configurtions {
    public static class Configuretion {
        public static IServiceCollection RegisterServiceDependencies(this IServiceCollection services)
        {
            #region Repositories
            services.AddTransient<IUnitOfWorkPattern, UnitOfWorkPattern>();
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IDepartmentRepository, DepartmentRepository>();
            services.AddTransient<ICountryRepository, CountryRepository>();
            services.AddScoped<ICityRespostory,CityRespostory>();
            #endregion
            #region Services
            services.AddTransient<IDepartMentService, DepartMentService>();
            services.AddTransient<IFileService, FileService>();
            services.AddTransient<ICountryService, CountryService>();
            services.AddTransient<ICityService, CityService>();
            #endregion
            return services;
        }
    }
}