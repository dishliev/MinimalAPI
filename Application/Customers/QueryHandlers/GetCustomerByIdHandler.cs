using Application.Abstractions;
using Application.Customers.Queries;
using Domain.Models;
using MediatR;

namespace Application.Customers.QueryHandlers
{
    public class GetCustomerByIdHandler : IRequestHandler<GetCustomerById, Customer>
    {
        private readonly ICustomerRepository _customerRepository;
        public GetCustomerByIdHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Customer> Handle(GetCustomerById request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetCustomerById(request.CustomerId);
            return customer;
        }
    }
}
