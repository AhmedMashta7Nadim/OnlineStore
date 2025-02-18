using InfraStractar.Repository.RepositoryModels;
using Microsoft.AspNetCore.Mvc;
using Models_Entity.DTO;
using Models_Entity.Models;

namespace OnlineStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserApplicationController : ControllerBase
    {
        private readonly UserApplicationRepository repository;

        public UserApplicationController(UserApplicationRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet("getAllUserApplications")]
        public async Task<ActionResult<UserApplication>> getAllAsync()
        {
            var response = await repository.Get_Summary();

            return Ok(response);
        }


        [HttpPost("Add_UserApplication")]
        public async Task<ActionResult<UserApplication>> AddUserApplicationAsync(UserApplicationDTO userApplication)
        {
            var query = await repository.Add(userApplication);
            if (query is null)
            {
                return BadRequest(" Exption ");
            }
            return Ok(query);
        }


    }
}
