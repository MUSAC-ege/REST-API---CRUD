using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderAPI.Models;

namespace OrderAPI.Controllers
{
    [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Client)]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly OrderContext _context;

        public UsersController(OrderContext context)
        {
            _context = context;
        }


        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/Users/5/Orders
        [HttpGet("{id}/Orders")]
        public async Task<ActionResult<IEnumerable<Order>>> GetUserOrders(int id)
        {
            if (!UserExists(id))
            {
                return NotFound();
            }
            else
            {
                var order = await _context.Orders.Where
                                (e => e.userId == id).ToListAsync();

                if (order == null)
                {
                    return NotFound();
                }

                return order;
            }
        }

        // GET: api/Users/5/Orders/Active
        [HttpGet("{id}/Orders/Active")]
        public async Task<ActionResult<IEnumerable<Order>>> GetActiveUserOrders(int id)
        {
            if (!UserExists(id))
            {
                return NotFound();
            }
            else
            {
                var order = await _context.Orders.Where
                                (e => e.userId == id && e.status==1).ToListAsync();

                if (order == null)
                {
                    return NotFound();
                }

                return order;
            }
        }

        // GET: api/Users/5/Orders/Active
        [HttpGet("{id}/Orders/Active/Channels")]
        public async Task<ActionResult<IEnumerable<Order>>> GetActiveUserOrdersChannel(int id)
        {
            if (!UserExists(id))
            {
                return NotFound();
            }
            else
            {
                var order = await _context.Orders.Where
                                (e => e.userId == id && e.status == 1).ToListAsync();

                if (order == null)
                {
                    return NotFound();
                }
                else
                {
                    var cnl = order.Select(e => new{e.emailChannel,e.smsChannel,e.pushChannel});

                    return Ok(cnl);
                }

            }
        }

        // GET: api/Users/5/Orders/Cancelled
        [HttpGet("{id}/Orders/Cancelled")]
        public async Task<ActionResult<IEnumerable<Order>>> GetCancelledUserOrders(int id)
        {
            if (!UserExists(id))
            {
                return NotFound();
            }
            else
            {
                var order = await _context.Orders.Where
                                (e => e.userId == id && e.status == 0).ToListAsync();

                if (order == null)
                {
                    return NotFound();
                }

                return order;
            }
        }

        // GET: api/Users/5/Messages
        [HttpGet("{id}/Messages")]
        public async Task<ActionResult<IEnumerable<Message>>> GetUserMessages(int id)
        {
            if (!UserExists(id))
            {
                return NotFound();
            }
            else
            {
                var msg = await _context.Messages.Where
                                (e => e.userId == id).ToListAsync();

                if (msg == null)
                {
                    return NotFound();
                }

                return msg;
            }
        }


        private bool UserExists(int id)
        {
            return _context.Orders.Any(e => e.id == id);
        }



    }
}
