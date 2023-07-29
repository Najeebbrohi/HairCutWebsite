using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HairCut.Models
{
    public class ServicesValidation
    {
        [Required(ErrorMessage = "Heading is required")]
        public string Heading { get; set; }
        [Required(ErrorMessage = "Text is required")]
        public string Text { get; set; }
        [Required(ErrorMessage = "Price is required")]
        public string Price { get; set; }
        public HttpPostedFileBase UserImagePath { get; set; }
    }
    [MetadataType(typeof(ServicesValidation))]
    public partial class Service
    {

    }
}