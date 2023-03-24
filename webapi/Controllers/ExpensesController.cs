using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.Context;
using webapi.Models;

namespace webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExpensesController : Controller
    {
        private readonly EFContext _context;

        public ExpensesController(EFContext context)
        {
            _context = context;
        }

        // GET: Expenses
        [HttpGet(Name = "GetExpenses")]
        public IEnumerable<Expenses> Get()
        {
              return _context.expenses.ToArray();
        }

        // GET: Expenses/Details/5
        [HttpGet("{id:int}")]
        public Expenses Details(int id)
        {
            return _context.expenses.FirstOrDefault(m => m.ID == id);
        }


        // POST: Expenses/Create
        [HttpPost("{type}")]
        public async Task<IActionResult> Create(string type, [Bind("ID,Name,Amount,TransactionDate")] Expenses expenses)
        {
            if (ModelState.IsValid)
            {
                if(type == "expense")
                {
                    expenses.Amount *= -1;
                } 
                _context.Add(expenses);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(expenses);
        }

        // POST: Expenses/Edit/5
        [HttpPost("edit/{type}/{id}")]
        public async Task<IActionResult> Edit(string type, int id, [Bind("ID,Name,Amount,TransactionDate")] Expenses expenses)
        {
            if (id != expenses.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (type == "expense")
                {
                    expenses.Amount *= -1;
                }
                try
                {
                    _context.Update(expenses);
                    await _context.SaveChangesAsync();
                }   
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExpensesExists(expenses.ID))
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
            return View(expenses);
        }


        // DELETE: Expenses/Delete/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.expenses == null)
            {
                return Problem("Entity set 'EFContext.expenses'  is null.");
            }
            var expenses = await _context.expenses.FindAsync(id);
            if (expenses != null)
            {
                _context.expenses.Remove(expenses);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExpensesExists(int id)
        {
          return (_context.expenses?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
