using Microsoft.Extensions.DependencyInjection;
using PhoneBook.Core.Domain.People.Contracts;
using PhoneBook.Core.Domain.Phones.Contracts;
using PhoneBook.Core.Domain.Tags.Contracts;
using PhoneBook.Infrastractures.Dal.SqlServer.People.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Endpoints.Api.ServicesExtentions
{
    public static class ServiceExtentions
    {
        public static void AddPhoneBookServices(this IServiceCollection services)
        {

        }
        public static void AddReposiotries(this IServiceCollection services)
        {
            services.AddScoped<TagRepository, EfTagRepository>();
            services.AddScoped<PersonRepository, EfPersonRepository>();
            services.AddScoped<PhoneRepositroy, EfPhoneRepository>();
        }
    }
}
