using Application.Abstractions;
using Application.Customers.Commands;
using Domain.Models;
using MediatR;

namespace Application.Customers.CommandHandlers
{
    public class CreateCustomerHandler : IRequestHandler<CreateCustomer, Customer>
    {
        private readonly ICustomerRepository _customerRepository;
        public CreateCustomerHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Customer> Handle(CreateCustomer request, CancellationToken cancellationToken)
        {
            var newCustomer = new Customer()
            {
                Name = request.Name
            };

            return await _customerRepository.CreateCustomer(newCustomer);
        }
    }
}
