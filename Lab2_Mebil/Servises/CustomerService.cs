using Lab2_Mebil.Data;
using Lab2_Mebil.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lab2_Mebil.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly MebilContext _context;  // Removed asterisk, using underscore

        public CustomerService(MebilContext context)
        {
            _context = context;  // Removed asterisk, using underscore
        }

        public async Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            return await _context.Customers.ToListAsync();  // Removed asterisk, using underscore
        }

        public async Task AddCustomerAsync(Customer customer)
        {
            _context.Customers.Add(customer);  // Removed asterisk, using underscore
            await _context.SaveChangesAsync();  // Already correct
        }
    }
}