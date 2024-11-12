using System.ComponentModel.DataAnnotations;
using System.Configuration;

namespace OrderAPI.Models
{
    public class Order
    {
        [Key]
        public int id { get; set; }

        [Required]
        public int userId { get; set; }

        [Range(1, 28)]
        public int day { get; set; }

        [Required]
        public DateOnly date { get; set; }

        [Range(500, 99999)]
        public decimal amount { get; set; }

        [Range(0, 1)]
        public int status { get; set; }
        public bool emailChannel { get; set; }
        public bool smsChannel { get; set; }
        public bool pushChannel { get; set; }

    }
}

