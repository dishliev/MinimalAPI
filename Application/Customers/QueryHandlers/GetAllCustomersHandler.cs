using Application.Abstractions;
using Application.Customers.Queries;
using Domain.Models;
using MediatR;

namespace Application.Customers.QueryHandlers
{
    public class GetAllCustomersHandler : IRequestHandler<GetAllCustomers, ICollection<Customer>>
    {
        private readonly ICustomerRepository _customerRepository;
        public GetAllCustomersHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<ICollection<Customer>> Handle(GetAllCustomers request, CancellationToken cancellationToken)
        {
            return await _customerRepository.GetAllCustomers();
        }
    }
}
