using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ch26_ModelBinding.Models
{
    [Bind(nameof(City))]
    public class AddressSummary
    {
        public string City { get; set; }

        [BindNever]
        public string Country { get; set; }
    }
}
