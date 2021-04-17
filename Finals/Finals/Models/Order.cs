using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace Finals.Models
{
    public class Order
    {
        [Key]
        public int OrderKey { get; set; }
        [Required(ErrorMessage = "First Name is Required")]
        [Display(Name = "First Name")]
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
        [Required(ErrorMessage = "Choose from the choices")]
        public virtual Service Service { get; set; }

    }
    public class Service
    {
        [Key]
        public int SerKey { get; set; }
        public string ServType { get; set; }
    }
}
