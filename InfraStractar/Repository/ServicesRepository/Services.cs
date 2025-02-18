using AutoMapper;
using InfraStractar.Data;
using InfraStractar.Repository.IServicesRepository;
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
            await context.SaveChangesAsync();
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

        public async Task<List<V>> Get_Summary()
        {
            var getAll=await context.Set<T>()
                .OrderDescending()
                .ToListAsync();

            var mapping=mapper.Map<List<V>>(getAll);

            return mapping;
        }
    }
}
