using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using InfraStractar.Data;
using InfraStractar.Repository.ServicesRepository;
using Microsoft.AspNetCore.Hosting;
using Models_Entity.DTO;
using Models_Entity.Models;
using Models_Entity.Models_Summary;

namespace InfraStractar.Repository.RepositoryModels
{
    public class ApplicationRepository : Services<Application, ApplicationSummary, ApplicationDTO>
    {
        private readonly StoryContext context;
        private readonly IMapper mapper;
        private readonly IWebHostEnvironment webHostEnvironment;

        public ApplicationRepository(StoryContext context, IMapper mapper, IWebHostEnvironment webHostEnvironment) : base(context, mapper)
        {
            this.context = context;
            this.mapper = mapper;
            this.webHostEnvironment = webHostEnvironment;
        }
       
        public async Task<Application> AddApplicationAsync(ApplicationDTO applicationDTO)
        {
            var model=mapper.Map<Application>(applicationDTO);
            if (model.App != null && model.App.Length > 0)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "uploads");

                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                string uniqueFileName = Path.GetFileName(model.App.FileName+"|"+Guid.NewGuid());
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await model.App.CopyToAsync(fileStream);
                }

                model.PathFile = $"{filePath}";
                await context.AddAsync(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                throw new Exception();
            }
        }
    }
}
