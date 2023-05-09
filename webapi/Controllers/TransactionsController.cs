using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create(string type, [Bind("ID,Name,Amount,TransactionDate,CategoryID")] Transactions transactions)
        {
            /*var asd = User.Identity.Name; // todo
            bool user = User?.Identity.IsAuthenticated ?? false;
            var email = User.FindFirst(ClaimTypes.Email)?.Value;
            _logger.LogInformation("TransactionsController LOG " + HttpContext.GetTokenAsync("Bearer", "access_token"));
            _logger.LogInformation("TransactionsController LOG EMAIL " + email);*/

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try 
            { 
                if(type == "expense")
                {
                    transactions.Amount *= -1;
                } 
                
                _context.Add(transactions);
                await _context.SaveChangesAsync();

                return Accepted(); 
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Something went wrong in the {nameof(Create)}");
                return Problem($"Something went wrong in the {nameof(Create)}", statusCode: 500);
            }
        }

        // POST: Transactions/Edit/5
        [HttpPost("edit/{type}/{id}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Edit(string type, int id, [Bind("ID,Name,Amount,TransactionDate,CategoryID")] Transactions transactions)
        {
            if (id != transactions.ID)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (type == "expense")
            {
                transactions.Amount *= -1;
            }

            try
            {
                _context.Update(transactions);
                await _context.SaveChangesAsync();

                return Accepted();
            }
            catch (Exception e)
            {
                if (!TransactionsExists(transactions.ID))
                {
                    return NotFound();
                }
                else
                {
                    _logger.LogError(e, $"Something went wrong in the {nameof(Edit)}");
                return Problem($"Something went wrong in the {nameof(Edit)}", statusCode: 500);
                }
            }
        }


        // DELETE: Transactions/Delete/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            if (_context.transactions == null)
            {
                return Problem("Entity set 'EFContext.transactions'  is null.");
            }

            var transaction = await _context.transactions.FindAsync(id);
            try
            {
                if (transaction != null)
                {
                    _context.transactions.Remove(transaction);
                }
                await _context.SaveChangesAsync();

                return Accepted();
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Something went wrong in the {nameof(Delete)}");
                return Problem($"Something went wrong in the {nameof(Delete)}", statusCode: 500);
            }
        }

        private bool TransactionsExists(int id)
        {
          return (_context.transactions?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
