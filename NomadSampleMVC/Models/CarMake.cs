using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NomadSampleMVC.Models
{
    public class CarMake
    {
        public int CarMakeID { get; set; }
        [Required]
        public string Make { get; set; }
    }
}