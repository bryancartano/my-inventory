using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;


namespace FinalProject.Models
{
    public class OrderForm
    {
        [Key]
        public int OrderKey { get; set; }
        [Required(ErrorMessage = "First Name is Required.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is Required.")]
        [Display(Name = "Last Name")]
        public  string LastName { get; set; }
        [Required(ErrorMessage = "Email is Required.")]
        public string Email { get; set; }
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }
        [Display(Name ="Phone Number")]
        public int PhoneNumber { get; set; }
        [Display(Name = "Services")]
        public ServiceType SType { get; set; }
    }

    public enum ServiceType
    {
        Select = 1,
        WeddingA = 2,
        WeddingB = 3,
        StudioPotrait = 4,
        AmbientShoot = 5,
        ProductShoot =6

    }
}
