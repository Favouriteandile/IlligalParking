using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IlligalParking.Models
{
    public class Vehicle
    {
        [BindNever]
        [Key]
        public int UserID { get; set; }
        [Required(ErrorMessage = "Enter Driver's name")]
        public string DriverName { get; set; }
        [Required(ErrorMessage = "Enter Vehicle Registration")]
        public string Registration { get; set; }
        [Required(ErrorMessage = "Enter Driver's Phone Number")]
        public string CellNumber { get; set; }
        [StringLength(13, ErrorMessage = "Enter Valid ID Number")]

        [Required(ErrorMessage = "Enter Driver's ID Number")]
        public string IDNumber { get; set; }
        [Required(ErrorMessage = "Provide Parking Type")]
        public string ParkingAssigned { get; set; }
    }
}
