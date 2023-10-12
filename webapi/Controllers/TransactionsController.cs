﻿using Microsoft.AspNetCore.Authorization;
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
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<TransactionsController> _logger;

        public TransactionsController(EFContext context, UserManager<IdentityUser> userManager, ILogger<TransactionsController> logger)
        {
            _context = context;
            _userManager = userManager;
            _logger = logger;
        }

        // GET: Transactions
        [Authorize]
        [HttpGet(Name = "GetTransactions")]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(User.Identity.Name);
                var transactions = _context.transactions.Include(trn => trn.ReferencedCategory).Where(trn => trn.UserID == user.Id);
                return Ok(transactions);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Something went wrong in the {nameof(GetAsync)}" + e);
                return StatusCode(500, "Internal server error " + e);
            }
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
        public async Task<IActionResult> Create(string type, [FromBody] Transactions transactions)
        {
            _logger.LogError( $"Something went wrong " + ModelState);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try 
            {
                if (HttpContext.User.Identity.IsAuthenticated)
                {
                    var user = await _userManager.FindByEmailAsync(User.Identity.Name);
                    transactions.UserID = user.Id;
                }

                if (type is "expense")
                {
                    transactions.Amount *= -1;
                }
                
                _context.Add(transactions);
                _logger.LogInformation(transactions.Name, transactions.UserID, transactions.ReferencedCategory);
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
