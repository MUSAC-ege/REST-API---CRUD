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
    public class MessagesController : ControllerBase
    {
        private readonly OrderContext _context;

        public MessagesController(OrderContext context)
        {
            _context = context;
        }

        // GET: api/Messages/All
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Message>>> GetMessages()
        {
            var msg = await _context.Messages.ToListAsync();

            if (msg == null)
            {
                return NotFound();
            }

            return msg;
        }


        // GET: api/Messages/EmailChannel
        [HttpGet("EmailChannel")]
        public async Task<ActionResult<IEnumerable<Message>>> GetMessagesByEmailChannel()
        {
            var msg = await _context.Messages.Where
                (e => e.channelCode == 1).ToListAsync();

            if (msg == null)
            {
                return NotFound();
            }

            return msg;
        }



        // GET: api/Messages/SmsChannel
        [HttpGet("SmsChannel")]
        public async Task<ActionResult<IEnumerable<Message>>> GetMessagesBySmsChannel()
        {
            var msg = await _context.Messages.Where
                (e => e.channelCode == 2).ToListAsync();

            if (msg == null)
            {
                return NotFound();
            }

            return msg;
        }


        // GET: api/Messages/PushChannel
        [HttpGet("PushChannel")]
        public async Task<ActionResult<IEnumerable<Message>>> GetMessagesByPushChannel()
        {
            var msg = await _context.Messages.Where
                (e => e.channelCode == 3).ToListAsync();

            if (msg == null)
            {
                return NotFound();
            }

            return msg;
        }




        private bool UserExists(int id)
        {
            return _context.Orders.Any(e => e.id == id);
        }

    }
}

