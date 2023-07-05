using Domain.Models;
using MediatR;

namespace Application.Customers.Queries
{
    public class GetCustomerById : IRequest<Customer>
    {
        public int CustomerId { get; set; }
    }
}
