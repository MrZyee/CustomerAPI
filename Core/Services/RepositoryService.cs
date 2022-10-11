using WebApplication4.Infrastructure.Repositories;
using WebApplication4.Models;

namespace WebApplication4.Core.Services
{
    public class RepositoryService
    {
        private readonly CustomerRepository _customerRepository;
        

        public RepositoryService(CustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Customer?> GetCustomer(int id)
        { 
            return  await _customerRepository.GetCustomer(id);
        }
        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await _customerRepository.GetCustomers();
        }
        public async Task AddCustomer(Customer customer)
        {
            await _customerRepository.AddCustomer(customer);
        }

        public async Task UpdateCustomer(Customer customer)
        {
            await _customerRepository.UpdateCustomer(customer);
        }
        public async Task DeleteCustomer(int id)
        {
            await _customerRepository.DeleteCustomer(id);
        }
    }

}
