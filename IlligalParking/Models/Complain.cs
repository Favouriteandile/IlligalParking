using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IlligalParking.Models
{
    public class Complain
    {
        [BindNever]
        [Key]
        public int ComplainID { get; set; }
        public string ReporterName { get; set; }
        [Required(ErrorMessage = "Enter Car Registration")]
        public string CarRegistration { get; set; }
        [Required(ErrorMessage = "Select Parking Type")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Select Parking Violation")]
        public string Violation { get; set; }
    }
}
