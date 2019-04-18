using System;
using System.Collections.Generic;

namespace DataSample.DataAccess
{
    public partial class TodoItem
    {
        public TodoItem()
        {
            CategoriesToTodoItems = new HashSet<CategoriesToTodoItem>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsDone { get; set; }
        public DateTime DueDate { get; set; }

        public virtual ICollection<CategoriesToTodoItem> CategoriesToTodoItems { get; set; }
    }
}