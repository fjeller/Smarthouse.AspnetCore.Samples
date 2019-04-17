using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.TagHelpers;

namespace BerlinSample.Core.DataClasses
{
    public class AddressData
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Street { get; set; }

        public string ZipCode { get; set; }

        public string City { get; set; }
    }
}
