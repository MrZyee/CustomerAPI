using Dapper;
using System.Data.SqlClient;
using WebApplication4.Models;

namespace WebApplication4.Infrastructure.Repositories
{
    public class CustomerRepository
    {
        private readonly SqlConnection _connection;
        private readonly IConfiguration _configuration;
        

        public CustomerRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connection = new SqlConnection(_configuration.GetConnectionString("MainBase"));   
        }

        public async Task <Customer?> GetCustomer(int id)
        {
            _connection.Open();
            return  _connection.Query<Customer>("SELECT * from Customer").FirstOrDefault(x => x.ID == id);
        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            _connection.Open();
            return await _connection.QueryAsync<Customer>("SELECT * from Customer");
        }

        public async Task AddCustomer(Customer customer)
        { 
            await _connection.QueryAsync($"INSERT INTO Customer(Name, Surname, Age) values ('@Firstname', '@LastName', @Age)",
                new { FirstName = customer.Name, LastName = customer.Surname, Age = customer.Age });
        }
        public async Task UpdateCustomer(Customer customer)
        {
           await _connection.QueryAsync($"UPDATE Customer SET Name = @FirstName, Surname = @Surname, Age = @Age WHERE Id = @Id", 
                new { FirstName = customer.Name, Surname = customer.Surname, Age = customer.Age, Id = customer.ID});
        }

        public async Task DeleteCustomer(int id)
        {
            await _connection.QueryAsync("DELETE FROM Customer WHERE ID = @Id", new { Id = id });
        }

    }
}
