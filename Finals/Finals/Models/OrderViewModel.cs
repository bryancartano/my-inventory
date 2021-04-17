using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace Finals.Models
{
    public class OrderViewModel
    {
        public string Firstname { get; set; }
        [Required(ErrorMessage = "Last Name is Required")]
        [Display(Name = "Last Name")]
        public string Lastname { get; set; }
        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid Format")]
        [Required(ErrorMessage = "Email is Required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Address is Required")]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        [Display(Name = "Service Type")]
        public int SerKey { get; set; }

    }
}
