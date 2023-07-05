using Domain.Models;
using MediatR;

namespace Application.Customers.Commands
{
    public class CreateCustomer : IRequest<Customer>
    {
        public string? Name { get; set; }
    }
}
