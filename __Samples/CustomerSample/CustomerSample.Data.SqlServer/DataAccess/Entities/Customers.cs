using System;
using System.Collections.Generic;

namespace CustomerSample.Data.SqlServer.DataAccess.Entities
{
    public partial class Customers
    {
        public int Id { get; set; }
        public string Lastname { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
    }
}
