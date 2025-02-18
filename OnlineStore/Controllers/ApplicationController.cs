using InfraStractar.Repository.RepositoryModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models_Entity.DTO;
using Models_Entity.Models;

namespace OnlineStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly ApplicationRepository repository;

        public ApplicationController(ApplicationRepository repository)
        {
            this.repository = repository;
        }
        [HttpPost("AddApplication")]
        public async Task<ActionResult<ApplicationDTO>> AddApllicationAsync(ApplicationDTO application)
        {
            var query=await repository.AddApplicationAsync(application);
            if(query is Exception)
            {
                return BadRequest("error");
            }
            return Ok(query);
        }
    }
}
