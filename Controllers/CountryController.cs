using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankApp.DB;
using BankApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BankApp.Controllers
{

    [Route("api/countries")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly BankContext _context;

        public CountryController(BankContext context)
        {
            _context = context;

           
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Country>>> GetCountryItems()
        {
            return await _context.Countries.ToListAsync();
        }


        // GET


        [HttpGet("{id}")]
        public async Task<ActionResult<Country>> GetCountryItem(int id)
        {
            var CountryItem = await _context.Countries.FindAsync(id);

            if (CountryItem == null)
            {
                return NotFound();
            }

            return CountryItem;
        }

        // POST

        [HttpPost]
        public async Task<IActionResult> PostCountryItem(Country item)
        {
            if (!ModelState.IsValid)

            {
                return ValidationProblem(ModelState);
            }
            _context.Countries.Add(item);
            await _context.SaveChangesAsync();
            return StatusCode(201);
        }

        // PUT
        [HttpPut("{Id}")]
        public async Task<IActionResult> PutCountryItem(int Id, Country item)
        {
            item.Id = Id;

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteCountry(int Id)
        {
            var Country = await _context.Countries.FindAsync(Id);

            if (Country == null)
            {
                return NotFound();
            }

            _context.Countries.Remove(Country);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}