using AutoMapper;
using Data;
using Domen;
using MikroServisProizvod.Application.BaseDtos;
using MikroServisProizvod.Application.DefaultServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikroServisProizvod.Implementation.ServiceImplementations
{
    public class BaseFindService<TEntity, TDto> : BaseMapperCommand<TEntity, TDto>, IFindCommand<TDto>
        where TEntity : BaseEntity
        where TDto : BaseDto
    {
        public BaseFindService(IGenericRepository<TEntity> genericRepository, IMapper mapper) : base(genericRepository, mapper)
        {
        }

        public TDto Find(long id)
        {
            TEntity entity;
            if (IncludedEntities.Length > 0)
            {
                entity = GenericRepository.FirstOrDefault(x => x.Id == id, IncludedEntities);
            }
            else
            {
                entity = GenericRepository.FirstOrDefault(x => x.Id == id);
            }

            if (entity == null) 
            {
                return null;
            }

            var parsedDto = Mapper.Map<TDto>(entity);

            return parsedDto;
        }
        public virtual string IncludedEntities => "";
    }
}
