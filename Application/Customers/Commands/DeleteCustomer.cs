using MediatR;

namespace Application.Customers.Commands
{
    public class DeleteCustomer : IRequest
    {
        public int CustomerId { get; set; }
    }
}
