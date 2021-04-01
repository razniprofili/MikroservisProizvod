using Data;
using Domen;
using FluentValidation;
using MikroServisProizvod.Application.BaseModels;
using MikroServisProizvod.Application.DefaultServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikroServisProizvod.Implementation.ServiceImplementations
{
    public class BaseDeleteCommand<TEntity> : BaseCommand<TEntity>, IDeleteCommand
        where TEntity : BaseEntity
    {
        public BaseDeleteCommand(IGenericRepository<TEntity> genericRepository) : base(genericRepository)
        {
        }

        public Empty Execute(long id)
        {
            var entity = GenericRepository.FirstOrDefault(x => x.Id == id);

            if (entity is null) // prvo proverimo da li entity za brisanje postoji u bazi
            {
                throw new ValidationException($"Nepostojeci {typeof(TEntity).Name.ToLower()} poslat na brisanje.");
            }

            GenericRepository.Delete(id);

            return new Empty();
        }
    }
}
