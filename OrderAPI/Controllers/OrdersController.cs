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
    public class OrdersController : ControllerBase
    {
        private readonly OrderContext _context;

        public OrdersController(OrderContext context)
        {
            _context = context;
        }


        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            return await _context.Orders.ToListAsync();
        }

        // GET: api/Orders/Active
        [HttpGet("Active")]
        public async Task<ActionResult<IEnumerable<Order>>> GetActiveOrders()
        {
            return await _context.Orders.Where(e=>e.status==1).ToListAsync();
        }


        // POST: api/Orders
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
            if (order.userId <= 0)
            {
                return BadRequest("UserID 0'dan Büyük Olmalı");
            }
            else
            {
                if (!ActiveOrderExists(order.userId))
                {
                    _context.Orders.Add(order);
                    await _context.SaveChangesAsync();

                    if (order.emailChannel == true)
                    {
                        var msg = new Message()
                        {
                            orderId = order.id,
                            userId = order.userId,
                            date = order.date,
                            message = "EMAIL Kanalından Mesaj Gönderildi",
                            channelCode = 1
                        };
                        _context.Messages.Add(msg);
                        await _context.SaveChangesAsync();

                    }

                    if (order.smsChannel == true)
                    {
                        var msg = new Message()
                        {
                            orderId = order.id,
                            userId = order.userId,
                            date = order.date,
                            message = "SMS Kanalından Mesaj Gönderildi",
                            channelCode = 2
                        };
                        _context.Messages.Add(msg);
                        await _context.SaveChangesAsync();

                    }

                    if (order.pushChannel == true)
                    {
                        var msg = new Message()
                        {
                            orderId = order.id,
                            userId = order.userId,
                            date = order.date,
                            message = "PUSH Kanalından Mesaj Gönderildi",
                            channelCode = 3
                        };
                        _context.Messages.Add(msg);
                        await _context.SaveChangesAsync();

                    }

                    return Ok("Talimat Oluşturuldu");

                }
                else
                {
                    return BadRequest("Aktif Talimat Mevcut");
                }
            }

        }

        // PATCH: api/Orders/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, Order order)
        {
            if (id != order.id)
            {
                return BadRequest();
            }

            _context.Entry(order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
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



        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.id == id);
        }
        private bool ActiveOrderExists(int id)
        {
            return _context.Orders.Any(e => e.userId == id && e.status == 1);
        }

        
       
    }
}
