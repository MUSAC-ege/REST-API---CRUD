using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace OrderAPI.Models
{
    public class User
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string? name { get; set; }

        [Required]
        [Range(1, 2)]
        public int userRole { get; set; }
    }
}
