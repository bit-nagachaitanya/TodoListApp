using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TodoListApp
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsCompleted { get; set; }
        public int NewId { get; set; }
    }
}