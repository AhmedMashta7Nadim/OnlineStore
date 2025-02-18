using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Models_Entity.DTO;
using Models_Entity.Models;
using Models_Entity.Models_Summary;

namespace InfraStractar.Mapping_Models
{
    internal class Mapping_Model:Profile
    {
        public Mapping_Model()
        {
            CreateMap<User, UserSummary>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();

            CreateMap<Application, ApplicationSummary>().ReverseMap();
            CreateMap<Application, ApplicationDTO>().ReverseMap();

            CreateMap<UserApplication, UserApplicationDTO>().ReverseMap();
        }
    }
}
