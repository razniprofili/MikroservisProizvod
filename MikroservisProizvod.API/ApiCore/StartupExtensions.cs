using AutoMapper;
using Common.Logger;
using Data;
using Domen;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using MikroServisProizvod.Application.IServices;
using MikroServisProizvod.Implementation.Profiles;
using MikroServisProizvod.Implementation.CommandImplementations.Proizvod;
using MikroServisProizvod.Implementation.CommandImplementations.Proizvod.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MikroservisProizvod.API.ApiCore
{
    public static class StartupExtensions 
    {
        public static void SetUpApplication(this IServiceCollection services)
        {
            services.AddTransient<IGenericRepository<Proizvod>, ProizvodRepository>();
            services.AddTransient<ISearchProizvodsCommand, SearchProizvodsCommand>();
            services.AddTransient<IAddProzivodCommand, AddProizvodCommand>();
            services.AddTransient<IUpdateProizvodCommand, UpdateProizvodCommand>();
            services.AddTransient<IFindProizvodCommand, FindProizvodCommand>();
            services.AddTransient<IDeleteProizvodCommand, DeleteProizvodCommand>();
            services.AddTransient<ITextFileAccessor, TextFileAccessor>();
            services.AddTransient<TextObjectAdapter>();
            services.AddTransient<LoggerMediator>();
        }

        public static void AddAutoMapper(this IServiceCollection services)
        {
            var assembly = typeof(ProizvodProfile).Assembly;
            var profiles = assembly.GetTypes().Where(x => x.IsClass && x.IsSubclassOf(typeof(Profile)));
            var mapper = new MapperConfiguration(x => {
                foreach (var profile in profiles)
                {
                    var parsedProfile = (Profile)Activator.CreateInstance(profile);
                    x.AddProfile(parsedProfile);
                }
            });
            var IMapper = mapper.CreateMapper();
            services.AddTransient(x => IMapper);
        }

        public static void AddValidators(this IServiceCollection services)
        {

            var dbContext = services.BuildServiceProvider().GetService<Context>();

            var assembly = typeof(ProizvodValidator).Assembly;
            var types = assembly.DefinedTypes.Where(x => x.GetInterfaces()
                                        .Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IValidator<>))).ToList();
            foreach (var type in types)
            {
                foreach (var validator in type.ImplementedInterfaces)
                {
                    services.AddTransient(validator, type);
                }
            }
        }
    }
}
