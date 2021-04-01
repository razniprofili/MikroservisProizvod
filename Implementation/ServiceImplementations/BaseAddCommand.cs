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
    public class BaseAddCommand<TEntity, TDto> : BaseMapperCommand<TEntity,TDto>,IAddCommand<TDto,TDto>
        where TEntity : BaseEntity
        where TDto : BaseDto
    {
        private readonly IValidator<TDto> Validator;
        public BaseAddCommand(IGenericRepository<TEntity> genericRepository, IMapper mapper, IValidator<TDto> validator) : base(genericRepository, mapper)
        {
            Validator = validator;
        }

        public virtual TDto Execute(TDto dto)
        {
            var validationResult = Validator.Validate(dto);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors.Select(x => new FluentValidation.Results.ValidationFailure(x.PropertyName,x.ErrorMessage)));
            }

            var mappedEntity = Mapper.Map<TEntity>(dto);

            GenericRepository.Add(mappedEntity);

            dto.Id = mappedEntity.Id;

            return dto;
        }
    }
}
