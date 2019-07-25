
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankApp.DB;
using BankApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BankApp.Controllers
{

    [Route("api/banks")]
    [ApiController]
    public class BanksController : ControllerBase
    {
        private readonly BankContext _context;

        public BanksController(BankContext context)
        {
            _context = context;

            
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bank>>> GetBankItems()
        {
            return await _context.Banks.ToListAsync();
        }

        // GET
       
        [HttpGet("{Id}")]
        public async Task<ActionResult<Bank>> GetBankItem(int id)
        {
            var BankItem = await _context.Banks.FindAsync(id);

            if (BankItem == null)
            {
                return NotFound();
            }

            return BankItem;
        }

        // POST
        [HttpPost]
        public async Task<IActionResult> PostBankItem(Bank item)
        {
            if (!ModelState.IsValid)

            {
                return ValidationProblem(ModelState);
            }
            _context.Banks.Add(item);
                await _context.SaveChangesAsync();
                return StatusCode(201);
            

        }

        // PUT: api/Todo/5
        [HttpPut("{Id}")]
        public async Task<IActionResult> PutBankItem(int Id, [FromBody] Bank item)
        {
            item.Id = Id;

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteBank(int id)
        {
            var Bank = await _context.Banks.FindAsync(id);

            if (Bank == null)
            {
                return NotFound();
            }

            _context.Banks.Remove(Bank);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        
    }




}