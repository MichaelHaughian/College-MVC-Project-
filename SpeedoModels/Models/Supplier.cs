using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SpeedoModels.Models
{
    public class Supplier
    {
        [Display(Name = "Supplier Id")]
        public int Id { get; set; }

        [Display(Name = "Supplier Name")]
        public string Name { get; set; }
    }
}