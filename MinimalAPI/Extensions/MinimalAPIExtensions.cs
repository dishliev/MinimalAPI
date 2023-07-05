using Application.Abstractions;
using Application.Customers.Commands;
using DataAccess.Repositories;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using MinimalAPI.Abstractions;

namespace MinimalAPI.Extensions
{
    public static class MinimalAPIExtensions
    {
        public static void RegisterServices(this WebApplicationBuilder builder)
        {
            string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<DatabaseContext>(opt => opt.UseSqlServer(connectionString));
            builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateCustomer).Assembly));
        }

        public static void RegisterEndpointDefinitions(this WebApplication app)
        {
            var endpointDefinitions = typeof(Program).Assembly
                .GetTypes()
                .Where(t => t.IsAssignableTo(typeof(IEndpointDefinition))
                    && !t.IsAbstract && !t.IsInterface)
                .Select(Activator.CreateInstance)
                .Cast<IEndpointDefinition>();

            foreach (var endpointDefinition in endpointDefinitions) 
            {
                endpointDefinition.RegisterEndpoints(app);
            }
        }
    }
}
