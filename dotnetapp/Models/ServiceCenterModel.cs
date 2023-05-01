using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotnetapp.Models
{
    public class ServiceCenterModel
    {
        [Key]
       
        public int ServiceCenterId { get; set; }
        [Required]
        [MaxLength(14)]
        public string ServiceCenterName { get; set; }
        [Required]
        
        public string ServiceCenterImageUrl { get; set; }
        [Required]
        [MaxLength(10)]
        public string ServiceCenterPhone { get; set; }
        [Required]
        [EmailAddress]
        public string ServiceCenterMailId { get; set; }
        [Required]
        [MaxLength(200)]
        public string ServiceCenterAddress { get; set; }
        [Required]
        [MaxLength(200)]
        public string ServiceCenterDescription { get; set; }
        
      
    }
}
