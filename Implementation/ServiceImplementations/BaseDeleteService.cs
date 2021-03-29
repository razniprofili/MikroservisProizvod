using Data;
using Domen;
using MikroServisProizvod.Application.DefaultServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikroServisProizvod.Implementation.ServiceImplementations
{
    public class BaseDeleteService<TEntity> : BaseService<TEntity>, IDeleteService
        where TEntity : BaseEntity
    {
        public BaseDeleteService(IGenericRepository<TEntity> genericRepository) : base(genericRepository)
        {
        }

        public void Delete(long id)
        {
            GenericRepository.Delete(id);
        }
    }
}
