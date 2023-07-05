using Application.Abstractions;
using Application.Customers.Commands;
using Domain.Models;
using MediatR;

namespace Application.Customers.CommandHandlers
{
    public class UpdateCustomerHandler : IRequestHandler<UpdateCustomer, Customer>
    {
        private readonly ICustomerRepository _customerRepository;
        public UpdateCustomerHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task<Customer> Handle(UpdateCustomer request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.UpdateCustomer(request.Name, request.CustomerId);
            return customer;
        }
    }
}
