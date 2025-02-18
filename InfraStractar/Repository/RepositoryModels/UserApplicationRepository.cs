using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using InfraStractar.Data;
using InfraStractar.Repository.ServicesRepository;
using Models_Entity.DTO;
using Models_Entity.Models;
using Models_Entity.Models_Summary;

namespace InfraStractar.Repository.RepositoryModels
{
    public class UserApplicationRepository : Services<UserApplication, UserApplication, UserApplicationDTO>
    {
        public UserApplicationRepository(StoryContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
