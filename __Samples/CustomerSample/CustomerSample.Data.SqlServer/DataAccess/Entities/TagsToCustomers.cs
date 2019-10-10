using System;
using System.Collections.Generic;

namespace CustomerSample.Data.SqlServer.DataAccess.Entities
{
    public partial class TagsToCustomers
    {
        public int CustomerId { get; set; }
        public int TagId { get; set; }
    }
}
