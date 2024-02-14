using DuyguAnalizi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DuyguAnalizi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PepperController : ControllerBase
    {
        private readonly PepperContext _context;

        public PepperController(PepperContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<List<Pepper>> GetProducts()
        {
            return await _context.Peppers.ToListAsync();
        }

        //[HttpGet("{id}")]
        //public async Task<Pepper> GetProductsById(int id)
        //{
        //    var pepper = await _context.Peppers.FindAsync(id);

        //    if (pepper == null)
        //    {
        //        return null;
        //    }

        //    return pepper;
        //}

        [HttpGet("{id}")]
        public async Task<ActionResult<Pepper>> GetProduct(long id)
        {
            var pepper = await _context.Peppers.FindAsync(id);

            if (pepper == null)
            {
                return NotFound();
            }

            return pepper;
        }
    }
}