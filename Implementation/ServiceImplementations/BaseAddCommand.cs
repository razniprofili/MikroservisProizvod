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

namespace MikroServisProizvod.Implementation.CommandImplementations
{
    public class BaseAddCommand<TEntity, TDto, TReadDto> : BaseMapperCommand<TEntity,TDto>,IAddCommand<TDto,TReadDto>
        where TEntity : BaseEntity
        where TDto : BaseDto
        where TReadDto : BaseDto
    {
        private readonly IValidator<TDto> _validator;
        public BaseAddCommand(IGenericRepository<TEntity> genericRepository, IMapper mapper, IValidator<TDto> validator) : base(genericRepository, mapper)
        {
            _validator = validator;
        }

        public virtual TReadDto Execute(TDto dto)
        {
            var validationResult = _validator.Validate(dto);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors.Select(x => new FluentValidation.Results.ValidationFailure(x.PropertyName,x.ErrorMessage)));
            }

            var mappedEntity = _mapper.Map<TEntity>(dto);

            _genericRepository.Add(mappedEntity);

            return _mapper.Map<TReadDto>(_genericRepository.FirstOrDefault(x => x.Id == mappedEntity.Id, IncludedPropertiesOnExport));
        }

        protected virtual string IncludedPropertiesOnExport => "";
    }
}
