using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BankApp.Controllers
{
    [Route("api/accountTypes")]
       [ApiController]
       public class AccountTypeController : ControllerBase
    {
        private readonly DB.BankContext _context;

        public AccountTypeController(DB.BankContext context)
        {
            _context = context;
        }


        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.AccountType>>> GetAccountTypeItem()
        {
            return await _context.AccountTypes.ToListAsync();
        }

        // GET
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.AccountType>> GetAccountTypeItem(int id)
        {
            var AccountTypeItem = await _context.AccountTypes.FindAsync(id);

            if (AccountTypeItem == null)
            {
                return NotFound();
            }

            return AccountTypeItem;
        }
        
        // POST
        [HttpPost]
        public async Task<IActionResult> PostAccountTypeItem(AccountType item)
        {
            if (!ModelState.IsValid)

            {
                return ValidationProblem(ModelState);
            }
            _context.AccountTypes.Add(item);
            await _context.SaveChangesAsync();
            return StatusCode(201);
        }

        // PUT: api/Todo/5
        [HttpPut("{Id}")]
        public async Task<IActionResult> PutAccountTypeItem(int Id, AccountType item)
        {
            item.Id = Id;

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteAccountType(int Id)
        {
            var AccountType = await _context.AccountTypes.FindAsync(Id);

            if (AccountType == null)
            {
                return NotFound();
            }

            _context.AccountTypes.Remove(AccountType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}