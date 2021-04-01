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
    public class BaseUpdateCommand<TEntity, TDto> : BaseMapperCommand<TEntity, TDto>, IUpdateCommand<TDto,TDto>
        where TEntity : BaseEntity
        where TDto : BaseDto
    {
        protected readonly IValidator<TDto> _validator;
        public BaseUpdateCommand(IGenericRepository<TEntity> genericRepository, IMapper mapper, IValidator<TDto> validator) : base(genericRepository, mapper)
        {
            _validator = validator;
        }

        public TDto Execute(TDto dto)
        {
            var entity = GenericRepository.FirstOrDefault(x => x.Id == dto.Id);

            if (entity is null) // prvo proverimo da li entitet za azuriranje postoji u bazi, pa onda sve ostalo
            {
                throw new ValidationException($"Nepostojeci {typeof(TEntity).Name.ToLower()} poslat na azuriranje.");
            }

            var validationResult = _validator.Validate(dto);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors.AsEnumerable());
            }

            var mappedEntity = Mapper.Map(dto, entity);

            GenericRepository.Update(mappedEntity);

            dto.Id = mappedEntity.Id;

            return dto;
        }
    }
}
