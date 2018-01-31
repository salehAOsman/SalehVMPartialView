using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SalehVMPartialView.Models
{
    //1 . create model then   -->  2 create model MyList 
    public class Person
    {
        [Display(Name = "Order")]
        public int Id { get; set; }
        [Required(ErrorMessage = "your name")]
        [Display(Name = "person name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "your city")]
        [Display(Name = "person city")]
        public string City { get; set; }
    }
}