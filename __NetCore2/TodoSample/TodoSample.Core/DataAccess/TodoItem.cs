﻿using System;
using System.Collections.Generic;

namespace TodoSample.Core.DataAccess
{
    public partial class TodoItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDone { get; set; }
        public DateTime DueDate { get; set; }
    }
}