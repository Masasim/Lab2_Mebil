using Lab2_Mebil.Data;
using Lab2_Mebil.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2_Mebil.Controllers
{
    public class CustomerController : Controller
    {
        private readonly MebilContext _context;

        public CustomerController(MebilContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(
            string searchString,
            string sortOrder = "id_desc",
            int pageSize = 5,
            int page = 1)
        {
            // Підготовка запиту з усіх Customer
            var customers = _context.Customers.AsQueryable();

            // Пошук
            if (!string.IsNullOrEmpty(searchString))
            {
                customers = customers.Where(c =>
                    c.name.Contains(searchString) ||
                    c.address.Contains(searchString) ||
                    c.bankDetails.Contains(searchString));
            }

            // Сортування
            customers = sortOrder switch
            {
                "id_asc" => customers.OrderBy(c => c.id),
                "id_desc" => customers.OrderByDescending(c => c.id),
                "name_asc" => customers.OrderBy(c => c.name),
                "name_desc" => customers.OrderByDescending(c => c.name),
                _ => customers.OrderByDescending(c => c.id)
            };

            // Пагінація
            var totalCustomers = await customers.CountAsync();
            var pagedCustomers = await customers
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var viewModel = new CustomerIndexViewModel
            {
                Customers = pagedCustomers,
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling(totalCustomers / (double)pageSize),
                PageSize = pageSize,
                SearchString = searchString,
                SortOrder = sortOrder
            };

            return View(viewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Customers.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        public async Task<IActionResult> Details(int id)
        {
            var customer = await _context.Customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var customer = await _context.Customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Customer customer)
        {
            if (id != customer.id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Customers.Any(c => c.id == id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }
    }

    

    public class CustomerIndexViewModel
    {
        public List<Customer> Customers { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public string SearchString { get; set; }
        public string SortOrder { get; set; }
    }
    

}