using System;
using System.Collections.Generic;

namespace DbSample.Data.DataAccess
{
    public partial class TodoItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsDone { get; set; }

        public string Description { get; set; }
    }
}