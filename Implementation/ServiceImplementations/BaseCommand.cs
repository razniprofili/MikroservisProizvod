using AutoMapper;
using Data;
using Domen;
using MikroServisProizvod.Application.BaseDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace MikroServisProizvod.Implementation.CommandImplementations
{
    public abstract class BaseCommand<TEntity>
        where TEntity : BaseEntity
    {
        protected readonly IGenericRepository<TEntity> _genericRepository;

        protected BaseCommand(IGenericRepository<TEntity> genericRepository)
        {
            _genericRepository = genericRepository;
        }
    }

    public abstract class BaseMapperCommand<TEntity, TDto> : BaseCommand<TEntity>
        where TEntity : BaseEntity
        where TDto : BaseDto
    {
        protected readonly IMapper _mapper;
        protected BaseMapperCommand(IGenericRepository<TEntity> genericRepository, IMapper mapper) : base(genericRepository)
        {
            _mapper = mapper;
        }
    }
}
