using Lab2_Mebil.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lab2_Mebil.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetCustomersAsync();
        Task AddCustomerAsync(Customer customer);
    }
}
