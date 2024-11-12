using System.ComponentModel.DataAnnotations;
using System.Configuration;

namespace OrderAPI.Models
{
    public class Message
    {
        [Key]
        public int id { get; set; }

        [Required]
        public int userId { get; set; }

        [Required]
        public int orderId { get; set; }

        [Required]
        [Range(1, 3)]
        public int channelCode { get; set; }

        [Required]
        public string? message { get; set; }

        [Required]
        public DateOnly date { get; set; }

    }
}


