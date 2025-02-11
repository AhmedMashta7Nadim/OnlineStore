using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auth.Authentication_Models;
using AutoMapper;
using InfraStractar.Data;
using InfraStractar.Repository.ServicesRepository;
using Microsoft.EntityFrameworkCore;
using Models_Entity.DTO;
using Models_Entity.Models;
using Models_Entity.Models_Summary;

namespace InfraStractar.Repository.RepositoryModels
{
    public class UserRepository : Services<User, UserSummary, UserDTO>
    {
        private readonly StoryContext context;
        private readonly IMapper mapper;
        private readonly TokenServices tokenServicess;

        public UserRepository(StoryContext context, IMapper mapper, TokenServices TokenServicess) : base(context, mapper)
        {
            this.context = context;
            tokenServicess = TokenServicess;
            this.mapper = mapper;
        }


     
        public async Task<string> LogInUser(UserName userName)
        {
            var search_user = await context.users.FirstOrDefaultAsync(x => x.Email == userName.Email);
            if(search_user is null)
            {
                return null;
            }
            var login = await tokenServicess.GeneretorToken(search_user);
            return login;
        }

    }
}
