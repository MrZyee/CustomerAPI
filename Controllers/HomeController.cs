using Microsoft.AspNetCore.Mvc;
using WebApplication4.Core.Services;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{

    [ApiController]
    [Route("[controller]")]

    public class HomeController : ControllerBase
    {

        private readonly RepositoryService _repositoryService;
        public HomeController(RepositoryService repositoryService)
        {
            _repositoryService = repositoryService;
        }

        [HttpGet("User")]
        public async Task <Customer?> GetCustomer(int id)
        {
            return await _repositoryService.GetCustomer(id);
        }

        [HttpGet]
        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await _repositoryService.GetCustomers();
        }

        [HttpPost]
        public async Task AddCustomers([FromBody] Customer customer)
        {
            await _repositoryService.AddCustomer(customer);
        }

        [HttpDelete]
        public async Task DeleteCustomer(int id)
        {
            await _repositoryService.DeleteCustomer(id);
        }


        [HttpPut]
        public async Task UpdateCustomer([FromBody] Customer customer)
        {
            await _repositoryService.UpdateCustomer(customer);
        }

    }
}
