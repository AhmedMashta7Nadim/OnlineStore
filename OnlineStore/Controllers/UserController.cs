using InfraStractar.Repository.RepositoryModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models_Entity.DTO;
using Models_Entity.Models;
using SQL_Coding.Sql_Models;

namespace OnlineStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserRepository userRepository;

        public UserController(UserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
      

        [HttpPost("Add_User")]
        public async Task<ActionResult<User>> AddAsync(UserDTO userDTO)
        {
            if (userDTO == null)
            {
                return BadRequest();
            }
           
            var requset = await userRepository.Add(userDTO);

            if (requset is null)
            {
                return BadRequest();
            }

            return Ok(requset);
        }

        [HttpPost("LogInUsers")]
        public async Task<ActionResult<string>> LogIn(UserName userName)
        {
            string request = await userRepository.LogInUser(userName);
            if (request is null)
            {
                return NotFound();
            }
            return Ok(request);
        }




    }
}
