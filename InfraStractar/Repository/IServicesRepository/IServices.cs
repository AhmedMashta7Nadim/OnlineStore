using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models_Entity.Entry_Models;

namespace InfraStractar.Repository.IServicesRepository
{
    public interface IServices<T,V,Z>
        where T : class
        where V : class
        where Z : class
    {
        Task<T> Add(Z entity);
        Task<V> GetId_Summary(Guid id);
        Task<List<V>> Get_Summary();
    }
}
