using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class PaymentMethod
    {
        [Key]
        public int KeyP { get; set; }
        [Required(ErrorMessage = "Choose What Payment Methood.")]
        [Display(Name = "Payment Method")]
        public Pmethod PayMethod { get; set; }
    }

    public enum Pmethod
    {
        BankDeposit = 1, 
        Gcash = 2,
        Credit = 3,
        Debit = 4,
        DownPayment = 5
    }
}
