using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DevPals_TestWork.Models
{
    public class CustomerModel
    {    
        [Key]
        public string UserName { get; set; }
        public string Pin { get; set; }
        public int Balance { get; set; }
    }
}
