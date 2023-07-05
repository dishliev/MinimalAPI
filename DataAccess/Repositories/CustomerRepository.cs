using Application.Abstractions;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DatabaseContext _databaseContext;
        public CustomerRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public async Task<Customer> CreateCustomer(Customer customer)
        {
            customer.DateCreated = DateTime.Now;
            customer.LastModified = DateTime.Now;
            _databaseContext.Add(customer);
            await _databaseContext.SaveChangesAsync();
            return customer;
        }

        public async Task DeleteCustomer(int customerId)
        {
            var customer = await _databaseContext.Customers.FirstOrDefaultAsync(customer => customer.Id == customerId);
            if (customer == null)
            {
                return;
            }

            _databaseContext.Customers.Remove(customer);
            await _databaseContext.SaveChangesAsync();
        }

        public async Task<ICollection<Customer>> GetAllCustomers()
        {
            return await _databaseContext.Customers.ToListAsync();
        }

        public async Task<Customer> GetCustomerById(int customerId)
        {
            return await _databaseContext.Customers.FirstOrDefaultAsync(p => p.Id == customerId);
        }

        public async Task<Customer> UpdateCustomer(string name, int customerId)
        {
            var customer = await _databaseContext.Customers.FirstOrDefaultAsync(p => p.Id == customerId);
            customer.Name = name;
            customer.LastModified = DateTime.Now;
            await _databaseContext.SaveChangesAsync();
            return customer;
        }
    }
}
