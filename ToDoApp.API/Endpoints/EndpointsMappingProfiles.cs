using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.API.Endpoints.Authentication;
using ToDoApp.API.Endpoints.Todo;
using ToDoApp.Data.Entities;

namespace ToDoApp.API.Endpoints
{
    public class EndpointsMappingProfiles : Profile
    {
        public EndpointsMappingProfiles()
        {
            CreateMap<RegistrationRequest, User>().ReverseMap();
            CreateMap<TodoRequest, ToDo>().ReverseMap();
        }
    }
}
