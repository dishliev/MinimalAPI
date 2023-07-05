using Domain.Models;

namespace MinimalAPI.Filters
{
    public class CustomerValidationFilter : IEndpointFilter
    {
        public async ValueTask<object> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            var customer = context.GetArgument<Customer>(1);
            if (string.IsNullOrEmpty(customer.Name))
            {
                return await Task.FromResult(Results.BadRequest("Customer not valid"));
            }

            return await next(context);
        }
    }
}
