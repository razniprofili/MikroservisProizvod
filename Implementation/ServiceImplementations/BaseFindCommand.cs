using AutoMapper;
using Data;
using Domen;
using FluentValidation;
using MikroServisProizvod.Application.BaseDtos;
using MikroServisProizvod.Application.DefaultServices;
using MikroServisProizvod.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikroServisProizvod.Implementation.CommandImplementations
{
    public class BaseFindCommand<TEntity, TDto> : BaseMapperCommand<TEntity, TDto>, IFindCommand<TDto>
        where TEntity : BaseEntity
        where TDto : BaseDto
    {
        public BaseFindCommand(IGenericRepository<TEntity> genericRepository, IMapper mapper) : base(genericRepository, mapper)
        {
        }

        public virtual TDto Execute(long id)
        {
            TEntity entity = IncludedEntities.Length > 0
                ? _genericRepository.FirstOrDefault(x => x.Id == id, IncludedEntities)
                : _genericRepository.FirstOrDefault(x => x.Id == id);

            if (entity == null)
            {
                //return null;
                throw new EntityNotFoundException($"Nepostojeci {typeof(TEntity).Name.ToLower()}.");
            }

            var parsedDto = _mapper.Map<TDto>(entity);

            return parsedDto;
        }

        public virtual string IncludedEntities => "";
    }
}
