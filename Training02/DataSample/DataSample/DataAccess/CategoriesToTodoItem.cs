using System;
using System.Collections.Generic;

namespace DataSample.DataAccess
{
    public partial class CategoriesToTodoItem
    {
        public int CategoryId { get; set; }
        public int TodoItemId { get; set; }

        public virtual Category Category { get; set; }
        public virtual TodoItem TodoItem { get; set; }
    }
}