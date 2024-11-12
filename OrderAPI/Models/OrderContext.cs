using Microsoft.EntityFrameworkCore;
using OrderAPI.Models;

namespace OrderAPI.Models
{
    public class OrderContext:DbContext
    {
        public OrderContext()
        {
        }

        public OrderContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User { id = 1, name = "Musa", userRole = 1 },
                new User { id = 2, name = "Erhan", userRole = 1 },
                new User { id = 3, name = "Hilal", userRole = 2 }
            );
            modelBuilder.Entity<Order>().HasData(
                new Order { id = 1, userId = 1, day = 1, date = new DateOnly(2024,12,1), amount = 500, status = 1, emailChannel = true, smsChannel = false, pushChannel = false },
                new Order { id = 2, userId = 1, day = 28, date = new DateOnly(2024, 12, 1), amount = 99999, status = 0, emailChannel = true, smsChannel = true, pushChannel = false },
                new Order { id = 3, userId = 2, day = 1, date = new DateOnly(2024, 12, 1), amount = 5000, status = 0, emailChannel = true, smsChannel = false, pushChannel = false },
                new Order { id = 4, userId = 2, day = 28, date = new DateOnly(2024, 12, 1), amount = 500, status = 0, emailChannel = false, smsChannel = false, pushChannel = true }
            );
            modelBuilder.Entity<Message>().HasData(
                new Message { id = 1, userId = 1, orderId = 1, channelCode = 1, message = "EMAIL kanalından mesaj gönderildi", date = new DateOnly(2024, 12, 1) },
                new Message { id = 2, userId = 1, orderId = 2, channelCode = 1, message = "EMAIL kanalından mesaj gönderildi", date = new DateOnly(2024, 12, 1) },
                new Message { id = 3, userId = 1, orderId = 2, channelCode = 2, message = "SMS kanalından mesaj gönderildi", date = new DateOnly(2024, 12, 1) },
                new Message { id = 4, userId = 2, orderId = 3, channelCode = 1, message = "EMAIL kanalından mesaj gönderildi", date = new DateOnly(2024, 12, 1) },
                new Message { id = 5, userId = 2, orderId = 4, channelCode = 3, message = "PUSH kanalından mesaj gönderildi", date = new DateOnly(2024, 12, 1) }
            );
        }


    }
}
