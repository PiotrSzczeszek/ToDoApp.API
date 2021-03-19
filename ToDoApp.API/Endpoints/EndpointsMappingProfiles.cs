using AutoMapper;
using System.Collections.Generic;
using ToDoApp.API.Endpoints.Authentication;
using ToDoApp.API.Endpoints.Todo;
using ToDoApp.API.Endpoints.Todo.Task;
using ToDoApp.Data.Entities;

namespace ToDoApp.API.Endpoints
{
    public class EndpointsMappingProfiles : Profile
    {
        public EndpointsMappingProfiles()
        {
            CreateMap<RegistrationRequest, User>().ReverseMap();
            CreateMap<TodoRequest, ToDo>().ReverseMap();
            CreateMap<TaskRequest, Task>().ReverseMap();
        }
    }
}
