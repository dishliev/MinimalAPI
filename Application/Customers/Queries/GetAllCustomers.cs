using Domain.Models;
using MediatR;

namespace Application.Customers.Queries
{
    public class GetAllCustomers : IRequest<ICollection<Customer>>
    {
    }
}
