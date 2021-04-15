using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EntprogFinalProject.Models
{
    public class OrderViewModel
    {
        public string Firstname { get; set; }
        [Required(ErrorMessage = "Last Name is Required")]
        [Display(Name = "Last Name")]
        public string Lastname { get; set; }
        [Required(ErrorMessage = "Email is Required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Address is Required")]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        public int SerKey { get; set; }
    }
}
