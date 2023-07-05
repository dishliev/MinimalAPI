using Application.Customers.Commands;
using Application.Customers.Queries;
using Domain.Models;
using MediatR;
using MinimalAPI.Abstractions;
using MinimalAPI.Filters;

namespace MinimalAPI.EndpointDefinitions
{
    public class CustomerEndpointDefinition : IEndpointDefinition
    {
        public void RegisterEndpoints(WebApplication app)
        {
            var customers = app.MapGroup("/api/customers");

            customers.MapGet("/{id}", GetCustomerById)
                .WithName("GetCustomerById");
            customers.MapPost("/", CreateCustomer)
                .AddEndpointFilter<CustomerValidationFilter>();
            customers.MapGet("/", GetAllCustomers);
            customers.MapPut("/{id}", UpdateCustomer)
                .AddEndpointFilter<CustomerValidationFilter>();
            customers.MapDelete("/{id}", DeleteCustomer);
        }

        private async Task<IResult> GetCustomerById(IMediator mediator, int id)
        {
            var getCustomer = new GetCustomerById { CustomerId = id };
            var customer = await mediator.Send(getCustomer);
            return TypedResults.Ok(customer);
        }

        private async Task<IResult> CreateCustomer(IMediator mediator, Customer customer)
        {
            var createCustomer = new CreateCustomer { Name = customer.Name };
            var createdCustomer = await mediator.Send(createCustomer);
            return Results.CreatedAtRoute("GetCustomerById", new { createdCustomer.Id }, createdCustomer);
        }

        private async Task<IResult> GetAllCustomers(IMediator mediator)
        {
            var getCommand = new GetAllCustomers();
            var customers = await mediator.Send(getCommand);
            return Results.Ok(customers);
        }

        private async Task<IResult> UpdateCustomer(IMediator mediator, Customer customer, int id)
        {
            var updateCustomer = new UpdateCustomer { CustomerId = id, Name = customer.Name };
            var updatedCustomer = await mediator.Send(updateCustomer);
            return TypedResults.Ok(updatedCustomer);
        }

        private async Task<IResult> DeleteCustomer(IMediator mediator, int id)
        {
            var deleteCustomer = new DeleteCustomer { CustomerId = id };
            await mediator.Send(deleteCustomer);
            return TypedResults.NoContent();
        }
    }
}
