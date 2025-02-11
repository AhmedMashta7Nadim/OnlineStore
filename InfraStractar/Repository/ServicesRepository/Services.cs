using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfraStractar.Repository.IServicesRepository;
using Models_Entity.Entry_Models;

namespace InfraStractar.Repository.ServicesRepository
{
    public class Services<T, V, Z> : IServices<T, V, Z>
        where T : class, IEntity
        where V : class
        where Z : class
    {
        public Task<T> Add(Z entity)
        {
            throw new NotImplementedException();
        }

        public Task<V> GetSummary(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
