using ATBiotechTest.Services;
using ATBiotechTest.Services.Database;
using ATBiotechTest.Services.Database.Interfaces;
using ATBiotechTest.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATBiotechTest
{
    public static class Container
    {
        public static void addScopes(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IContactsService, ContactsService>();
            serviceCollection.AddScoped<IContactsRepository, ContactsRepository>();
        }
    }
}
