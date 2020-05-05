using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NomadSampleMVC.Models
{
    public class CarModel
    {
        public int CarModelID { get; set; }
        public int CarMakeID { get; set; }
        public int CarTypeID { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }

        public virtual CarMake CarMake { get; set; }
        public virtual CarType CarType { get; set; }
    }
}