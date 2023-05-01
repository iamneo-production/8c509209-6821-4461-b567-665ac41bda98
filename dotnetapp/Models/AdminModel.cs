using Castle.Components.DictionaryAdapter;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotnetapp.Models
{
    public class AdminModel
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int Id { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(8)]
        public string Password { get; set; }
        [Required]
        [MaxLength(10)]
        public string MobileNumber { get; set;}
        [Required]
        [MaxLength(5)]
        public string UserRole { get; set; }

        
    }
}
