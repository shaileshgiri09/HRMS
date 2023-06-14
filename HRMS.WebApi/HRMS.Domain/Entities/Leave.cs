using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Domain.Entities
{
    public class Leave
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Leave reasone can't be blank")]
        public string LeaveReasone { get; set; }

        [Required(ErrorMessage = "Please pick the fromDate")]
        public DateTime FromDate { get; set; }

        [Required(ErrorMessage = "Please pick the To Date")]
        public DateTime ToDate { get; set; }

       
        
    }
}
