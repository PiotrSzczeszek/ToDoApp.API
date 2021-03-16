using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApp.API.Endpoints.Todo
{
    public class TodoRequest
    {
        public string Title { get; set; }
        public DateTime DueDate { get; set; }


    }
}
