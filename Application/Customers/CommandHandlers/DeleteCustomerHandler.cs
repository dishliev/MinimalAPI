using Application.Abstractions;
using Application.Customers.Commands;
using MediatR;

namespace Application.Customers.CommandHandlers
{
    public class DeleteCustomerHandler : IRequestHandler<DeleteCustomer>
    {
        private readonly ICustomerRepository _customerRepository;
        public DeleteCustomerHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task Handle(DeleteCustomer request, CancellationToken cancellationToken)
        {
            await _customerRepository.DeleteCustomer(request.CustomerId);
        }
    }
}
