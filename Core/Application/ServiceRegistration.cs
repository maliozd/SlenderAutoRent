using Application.Features.Cars.Mapping;
using Application.Features.Cars.Validators;
using Application.Rules;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;

using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddSubClassesOfType(Assembly.GetExecutingAssembly(), typeof(BaseRules));
            services.AddAutoMapper(typeof(CarMappingProfile));
            services.AddMediatR(typeof(ServiceRegistration));
            services.AddFluentValidationAutoValidation().AddValidatorsFromAssemblyContaining<CreateCarValidator>(ServiceLifetime.Scoped);
        }

        //TODO --> engin demiroğ search for this extension method
        public static IServiceCollection AddSubClassesOfType(this IServiceCollection services, Assembly assembly, Type type, Func<IServiceCollection, Type, IServiceCollection>? addWithLifeCycle = null)
        {
            var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();
            foreach (var item in types)
            {
                if (addWithLifeCycle == null)
                {
                    services.AddScoped(item);
                }
                else
                {
                    addWithLifeCycle(services, type);
                }
            }
            return services;
        }
    }

}
