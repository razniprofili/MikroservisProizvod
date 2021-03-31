using Data;
using Domen;
using FluentValidation;
using MikroServisProizvod.Application.DefaultServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikroServisProizvod.Implementation.ServiceImplementations
{
    public class BaseDeleteService<TEntity> : BaseCommand<TEntity>, IDeleteCommand
        where TEntity : BaseEntity
    {
        public BaseDeleteService(IGenericRepository<TEntity> genericRepository) : base(genericRepository)
        {
        }

        public void Delete(long id)
        {
            var entity = GenericRepository.FirstOrDefault(x => x.Id == id);

            if (entity is null) // prvo proverimo da li entity za brisanje postoji u bazi
            {
                throw new ValidationException($"Nepostojeci {typeof(TEntity).Name.ToLower()} poslat na brisanje.");
            }

            GenericRepository.Delete(id);
        }
    }
}
