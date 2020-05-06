using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NomadSampleMVC.Models
{
    public class CarImage
    {
        public int CarImageID { get; set; }
        [Required]
        [StringLength(255)]
        public string FileName { get; set; }
        [StringLength(100)]
        public string ContentType { get; set; }
        public byte[] Content { get; set; }
        public int CarModelID { get; set; }

        public virtual CarModel CarModel { get; set; }
    }
}