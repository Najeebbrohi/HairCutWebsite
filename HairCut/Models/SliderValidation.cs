using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HairCut.Models
{
    public class SliderValidation
    {
        [Required(ErrorMessage = "Heading is required")]
        public string Heading { get; set; }
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Phone is required")]
        public string Phone { get; set; }
        public HttpPostedFileBase UserImagePath { get; set; }
    }
    [MetadataType(typeof(SliderValidation))]
    public partial class Slider
    {
    }
}