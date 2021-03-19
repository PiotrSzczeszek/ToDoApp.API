using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApp.API.Endpoints.Todo.Task
{
    public class MultipleTasksRequest
    {
        public IEnumerable<string> TasksContents { get; set; }
    }
}
