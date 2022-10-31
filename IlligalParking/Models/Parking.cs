using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IlligalParking.Models
{
    public class Parking
    {
        [BindNever]
        [Key]
        public int TypeID { get; set; }
        public string Name { get; set; }
        public string UsableTo { get; set; }
        public string Restriction { get; set; }
    }
}
