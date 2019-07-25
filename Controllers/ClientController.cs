
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankApp.DB;
using BankApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BankApp.Controllers
{

    [Route("api/clients")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly BankContext _context;

        public ClientController(BankContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> GetClientItems()
        {
            return await _context.Clients.ToListAsync();
        }


        // GET
        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetClientItem(int id)
        {
            var ClientItem = await _context.Clients.FindAsync(id);

            if (ClientItem == null)
            {
                return NotFound();
            }

            return ClientItem;
        }

        // POST
        [HttpPost]
        public async Task<IActionResult> PostBankItem(Client item)
        {
            if (!ModelState.IsValid)

            {
                return ValidationProblem(ModelState);
            }
            _context.Clients.Add(item);
            await _context.SaveChangesAsync();
            return StatusCode(201);
        }

        // PUT
        [HttpPut("{Id}")]
        public async Task<IActionResult> PutClientItem(int Id, Client item)
        {
            item.Id = Id;

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            var Client = await _context.Clients.FindAsync(id);

            if (Client == null)
            {
                return NotFound();
            }

            _context.Clients.Remove(Client);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}