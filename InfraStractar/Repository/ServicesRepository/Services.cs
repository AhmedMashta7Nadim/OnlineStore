using AutoMapper;
using InfraStractar.Data;
using InfraStractar.Repository.IServicesRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Models_Entity.Entry_Models;

namespace InfraStractar.Repository.ServicesRepository
{
    public class Services<T, V, Z> : IServices<T, V, Z>
        where T : class, IEntity
        where V : class
        where Z : class
    {
        private readonly StoryContext context;
        private readonly IMapper mapper;

        public Services(StoryContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }


        public async Task<T> Add(Z entity)
        {
            var mpping = mapper.Map<T>(entity);
            var request = await context.Set<T>().AddAsync(mpping);
            try
            {
                await context.SaveChangesAsync();
            }
            catch (Exception exp)
            {
                throw new Exception("Email is not Unique");
            }
            return request.Entity;
        }

        public async Task<V> GetId_Summary(Guid id)
        {
            var getId = await context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
            if (getId is null)
            {
                return null;
            }
            var mapping = mapper.Map<V>(getId);

            return mapping;
        }

    }
}
