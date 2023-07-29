using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HairCut.Models
{
    public class BarbarValidation
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Designation is required")]
        public string Designation { get; set; }
        public HttpPostedFileBase UserImagePath { get; set; }
    }
    [MetadataType(typeof(BarbarValidation))]
    public partial class Barbar
    {
    }
}