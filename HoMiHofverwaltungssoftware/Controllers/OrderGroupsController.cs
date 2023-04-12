using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HoMiHofverwaltungssoftware.Data;
using HoMiHofverwaltungssoftware.Models;

namespace HoMiHofverwaltungssoftware.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderGroupsController : ControllerBase
    {
        private readonly HoMiHofverwaltungssoftwareContext _context;

        public OrderGroupsController(HoMiHofverwaltungssoftwareContext context)
        {
            _context = context;
        }

        // GET: api/OrderGroups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderGroupsModel>>> GetOrderGroupsModel()
        {
          if (_context.OrderGroupsModel == null)
          {
              return NotFound();
          }
            return await _context.OrderGroupsModel.ToListAsync();
        }

        // GET: api/OrderGroups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderGroupsModel>> GetOrderGroupsModel(int id)
        {
          if (_context.OrderGroupsModel == null)
          {
              return NotFound();
          }
            var orderGroupsModel = await _context.OrderGroupsModel.FindAsync(id);

            if (orderGroupsModel == null)
            {
                return NotFound();
            }

            return orderGroupsModel;
        }

        // PUT: api/OrderGroups/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderGroupsModel(int id, OrderGroupsModel orderGroupsModel)
        {
            if (id != orderGroupsModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(orderGroupsModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderGroupsModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/OrderGroups
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrderGroupsModel>> PostOrderGroupsModel(OrderGroupsModel orderGroupsModel)
        {
          if (_context.OrderGroupsModel == null)
          {
              return Problem("Entity set 'HoMiHofverwaltungssoftwareContext.OrderGroupsModel'  is null.");
          }
            _context.OrderGroupsModel.Add(orderGroupsModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrderGroupsModel", new { id = orderGroupsModel.Id }, orderGroupsModel);
        }

        // DELETE: api/OrderGroups/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderGroupsModel(int id)
        {
            if (_context.OrderGroupsModel == null)
            {
                return NotFound();
            }
            var orderGroupsModel = await _context.OrderGroupsModel.FindAsync(id);
            if (orderGroupsModel == null)
            {
                return NotFound();
            }

            _context.OrderGroupsModel.Remove(orderGroupsModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderGroupsModelExists(int id)
        {
            return (_context.OrderGroupsModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
