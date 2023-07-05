using Domain.Models;

namespace Application.Abstractions
{
    public interface ICustomerRepository
    {
        Task<ICollection<Customer>> GetAllCustomers();
        Task<Customer> GetCustomerById(int customerId);
        Task<Customer> CreateCustomer(Customer customer);
        Task<Customer> UpdateCustomer(string name, int customerId);
        Task DeleteCustomer(int customerId);
    }
}
