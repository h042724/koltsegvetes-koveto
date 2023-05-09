using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using webapi.Context;
using webapi.Models;

namespace webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionsController : Controller
    {
        private readonly EFContext _context;
        private readonly UserManager<ApiUser> _userManager;
        private readonly ILogger<TransactionsController> _logger;
        private ApiUser _user;

        public TransactionsController(EFContext context, UserManager<ApiUser> userManager, ILogger<TransactionsController> logger)
        {
            _context = context;
            _userManager = userManager;
            _logger = logger;
        }

        // GET: Transactions
        //[Authorize]
        [HttpGet(Name = "GetTransactions")]
        public IEnumerable<Transactions> Get()
        {
              //return _context.transactions.ToArray();
              return _context.transactions.Include(u => u.ReferencedCategory);
        }

        // GET: Transactions/Details/5
        [HttpGet("{id:int}")]
        public Transactions Details(int id)
        {
            return _context.transactions.Include(u => u.ReferencedCategory).FirstOrDefault(m => m.ID == id);
        }


        // POST: Transactions/Create
        [HttpPost("{type}")]
        public async Task<IActionResult> Create(string type, [Bind("ID,Name,Amount,TransactionDate,CategoryID")] Transactions transactions)
        {
            var asd = User.Identity.Name;
            //bool user = User?.Identity.IsAuthenticated ?? false;
            var email = User.FindFirst(ClaimTypes.Email)?.Value;
            _logger.LogInformation("TransactionsController LOG " + HttpContext.GetTokenAsync("Bearer", "access_token"));
            _logger.LogInformation("TransactionsController LOG EMAIL " + email);

            if (ModelState.IsValid)
            {
                if(type == "expense")
                {
                    transactions.Amount *= -1;
                } 
                _context.Add(transactions);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            //return View(_context.transactions.Include(u => u.ReferencedCategory));
            return RedirectToAction(nameof(Index));

        }

        // POST: Transactions/Edit/5
        [HttpPost("edit/{type}/{id}")]
        public async Task<IActionResult> Edit(string type, int id, [Bind("ID,Name,Amount,TransactionDate,CategoryID")] Transactions transactions)
        {
            if (id != transactions.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (type == "expense")
                {
                    transactions.Amount *= -1;
                }
                try
                {
                    _context.Update(transactions);
                    await _context.SaveChangesAsync();
                }   
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransactionsExists(transactions.ID))
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
            return View(transactions);
        }


        // DELETE: Transactions/Delete/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.transactions == null)
            {
                return Problem("Entity set 'EFContext.transactions'  is null.");
            }
            var transactions = await _context.transactions.FindAsync(id);
            if (transactions != null)
            {
                _context.transactions.Remove(transactions);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransactionsExists(int id)
        {
          return (_context.transactions?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
