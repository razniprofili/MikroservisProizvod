using AutoMapper;
using Data;
using Domen;
using FluentValidation;
using MikroServisProizvod.Application.BaseDtos;
using MikroServisProizvod.Application.DefaultServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikroServisProizvod.Implementation.ServiceImplementations
{
    public class BaseUpdateService<TEntity, TDto> : BaseMapperCommand<TEntity, TDto>, IUpdateCommand<TDto>
        where TEntity : BaseEntity
        where TDto : BaseDto
    {
        protected readonly IValidator<TDto> _validator;
        public BaseUpdateService(IGenericRepository<TEntity> genericRepository, IMapper mapper, IValidator<TDto> validator) : base(genericRepository, mapper)
        {
            _validator = validator;
        }

        public virtual TDto Update(TDto dto)
        {
            var validationResult = _validator.Validate(dto);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors.AsEnumerable());
            }

            var entity = GenericRepository.FirstOrDefault(x => x.Id == dto.Id);

            var mappedEntity = Mapper.Map(dto, entity);

            GenericRepository.Update(mappedEntity);

            dto.Id = mappedEntity.Id;

            return dto;
        }
    }
}
