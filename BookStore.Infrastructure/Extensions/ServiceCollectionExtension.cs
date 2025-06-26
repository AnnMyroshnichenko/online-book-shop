using BookStore.Domain.Entities;
using BookStore.Domain.Repositories;
using BookStore.Infrastructure.Persistance;
using BookStore.Infrastructure.Repositories;
using BookStore.Infrastructure.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructure (this IServiceCollection services, IConfiguration configuration) 
        {
            var connectionString = configuration.GetConnectionString("BookStoreDb");
            services.AddDbContext<BookStoreDbContext>(options => 
                options.UseSqlServer(connectionString));

            services.AddIdentityApiEndpoints<User>()
                .AddEntityFrameworkStores<BookStoreDbContext>();

            services.AddScoped<IBookSeeder, BookSeeder>();
            services.AddScoped<IBookRepository, BookRepository>();
        }
    }
}
