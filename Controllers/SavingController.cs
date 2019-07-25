using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankApp.DB;
using BankApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BankApp.Controllers
{

    [Route("api/savings")]
    [ApiController]
    public class SavingsController : ControllerBase
    {
        private readonly BankContext _context;

        public SavingsController(BankContext context)
        {
            _context = context;

           
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Saving>>> GetSavingItems()
        {
            return await _context.Savings.ToListAsync();
        }


        // GET
        [HttpGet("{id}")]
        public async Task<ActionResult<Saving>> GetSavingItem(int id)
        {
            var SavingItem = await _context.Savings.FindAsync(id);

            if (SavingItem == null)
            {
                return NotFound();
            }

            return SavingItem;
        }

        // POST
        [HttpPost]
        public async Task<IActionResult> PostSavingItem(Saving item)
        {
            if (!ModelState.IsValid)

            {
                return ValidationProblem(ModelState);
            }
            _context.Savings.Add(item);
            await _context.SaveChangesAsync();
            return StatusCode(201);


        } // PUT: api/Todo/5
        [HttpPut("{Id}")]
        public async Task<IActionResult> PutSavingItem(int Id, Saving item)
        {
            item.Id = Id;

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteSaving(int Id)
        {
            var Saving = await _context.Savings.FindAsync(Id);

            if (Saving == null)
            {
                return NotFound();
            }

            _context.Savings.Remove(Saving);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}