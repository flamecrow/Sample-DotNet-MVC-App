using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NomadSampleMVC.Models
{
    public class CarType
    {
        public int ID { get; set; }
        public string Type { get; set; }

        public virtual ICollection<CarMake> CarMakes { get; set; }
    }
}
    