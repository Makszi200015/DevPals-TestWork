using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DevPals_TestWork.Models
{
    public class HistoryModel
    {
        [Key]
        public int Id { get; set; }
        public string UsedUserName { get; set; }
        public int WithdrawnCash { get; set; }
        public bool OperationState { get; set; }
    }
}
