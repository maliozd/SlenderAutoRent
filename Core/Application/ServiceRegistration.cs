using Application.Mappings;
using Application.Services.Abstract;
using Application.Services.Concrete;
using Application.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;

using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class ServiceRegistration
    {
        public static void AddAplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfiles));
            services.AddMediatR(typeof(ServiceRegistration));
            services.AddFluentValidationAutoValidation().AddValidatorsFromAssemblyContaining<CreateCarValidator>(ServiceLifetime.Scoped);

            services.AddScoped<ICarService, CarService>();
        }
    }
}
