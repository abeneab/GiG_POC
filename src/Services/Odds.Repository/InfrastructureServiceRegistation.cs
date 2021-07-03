﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Odds.Domain.Seed;
using Odds.Repository.Context;
using Odds.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odds.Repository
{
    public static class InfrastructureServiceRegistation
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddDbContext<OddsContext>(options =>
            //options.UseLazyLoadingProxies();
            //options.UseNpgsql(configuration.GetConnectionString("OddsonnectionString"));) ;
            services.AddDbContext<OddsContext>(options =>
            {
                //options.UseLazyLoadingProxies();
                options.UseNpgsql(configuration.GetConnectionString("OddsConnectionString"));
            });


            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
            return services;
        }
    }
}
