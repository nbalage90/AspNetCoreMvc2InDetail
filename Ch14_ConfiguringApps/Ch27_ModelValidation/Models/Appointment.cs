using Ch27_ModelValidation.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ch27_ModelValidation.Models
{
    public class Appointment
    {
        [Required]
        [Display(Name = "name")]
        public string ClientName { get; set; }

        [UIHint("Date")]
        [Required(ErrorMessage = "Please enter a date")]
        [Remote("ValidateDate", "Home")]
        public DateTime Date { get; set; }

        [MustBeTrue(ErrorMessage = "You must accept the terms")]
        public bool TermsAccepted { get; set; }
    }
}
