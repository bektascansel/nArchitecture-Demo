﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.Application.Rules;
using FluentValidation;
using Core.Application.Pipelines.Validation;
using Core.Application.Pipelines.Transaction;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.CrossCuttingConcerns.Serilog;
using Core.CrossCuttingConcerns.Serilog.Logger;

namespace Application
{
    //her katman projesinin kendi Ioc'leri için extension yazıyoruz.
    public static class ApplicationServiceRegistration
    {

        //extension yazabilmemiz için metotun ve class'ın  static olması gerekmektedir.
        //neyi extension edecek ise onu this ile belitriyoruz.
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());  
            services.AddSubClassesOfType(Assembly.GetExecutingAssembly(),typeof(BaseBusinessRules));
            
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            
            services.AddMediatR(configuration =>
            {

                configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                configuration.AddOpenBehavior(typeof(RequestValidationBehavior<,>));
                configuration.AddOpenBehavior(typeof(TransactionScopeBehavior<,>));

                configuration.AddOpenBehavior(typeof(CachingBehavior<,>));


                configuration.AddOpenBehavior(typeof(LoggingBehavior<,>));

            });

            //services.AddSingleton<LoggerServiceBase, FileLogger>();
            services.AddSingleton<LoggerServiceBase, MsSqlLogger>();

            return services;
        }

        //business kurallarını toplu olarak bir kerede Ioc ye ekliyoruz.
        public static IServiceCollection AddSubClassesOfType(
            this IServiceCollection services,
            Assembly assembly,
            Type type,
             Func<IServiceCollection, Type, IServiceCollection>? addWithLifeCycle = null
  )
        {
            var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();
            foreach (var item in types)
                if (addWithLifeCycle == null)
                    services.AddScoped(item);

                else
                    addWithLifeCycle(services, type);
            return services;
        }




    }
}
