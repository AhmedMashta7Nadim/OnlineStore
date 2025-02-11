using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStractar.Repository.IServicesRepository
{
    public interface IServices<T,V,Z>
        where T : class
        where V : class
        where Z : class
    {
        Task<T> Add(Z entity);
        Task<V> GetSummary(Guid id);
    }
}
