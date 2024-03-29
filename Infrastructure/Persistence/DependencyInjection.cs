﻿using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;
using Persistence.Repositories;

namespace Persistence
{
    public static class DependencyInjection
    {
        public static void AddPersistence(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseInMemoryDatabase(databaseName: "WeatherForecastDb"),
                    ServiceLifetime.Transient);

            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IWeatherForecastRepository, WeatherForecastRepository>();
        }
    }
}
