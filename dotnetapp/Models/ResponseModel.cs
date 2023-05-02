using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace dotnetapp.Models
{
    public class ResponseModel
    {
        public dynamic Response { get; set; }
        public string Message { get; set; }
        public bool? Status { get; set; }
        public string ErrorMessage { get; set; }
       
        
    
       
       
       
    }
}
