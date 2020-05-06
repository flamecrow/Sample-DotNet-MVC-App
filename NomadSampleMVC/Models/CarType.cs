using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NomadSampleMVC.Models
{
    public class CarType
    {
        public int ID { get; set; }
        [Required]
        public string Type { get; set; }
    }
}
    