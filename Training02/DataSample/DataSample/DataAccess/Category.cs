using System;
using System.Collections.Generic;

namespace DataSample.DataAccess
{
    public partial class Category
    {
        public Category()
        {
            CategoriesToTodoItems = new HashSet<CategoriesToTodoItem>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<CategoriesToTodoItem> CategoriesToTodoItems { get; set; }
    }
}