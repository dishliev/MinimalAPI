using Domain.Models;
using MediatR;

namespace Application.Customers.Commands
{
    public class UpdateCustomer : IRequest<Customer>
    {
        public int CustomerId { get; set; }
        public string? Name { get; set; }
    }
}
