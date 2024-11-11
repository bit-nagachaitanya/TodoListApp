using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TodoListApp.App_Code
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsCompleted { get; set; }
    }
}