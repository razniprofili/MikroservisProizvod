using Domen;
using FluentValidation;
using MikroServisProizvod.Application.IServices.Commands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikroServisProizvod.Implementation.CommandImplementations.Proizvod
{
    public class ProizvodValidator : AbstractValidator<ProizvodDto>
    {
        public ProizvodValidator(Context context)
        {

            RuleFor(x => x.Naziv)
                .Must(x => !String.IsNullOrEmpty(x))
                .WithMessage("Naziv ne sme biti prazan.")
                .Must((x, y) => context.Proizvod.FirstOrDefault(z => z.Naziv == y) == null)
                .WithMessage("Naziv mora biti jedinstven.");
            RuleFor(x => x.JedinicaMereId)
                .Must((x, y) => context.JedinicaMere.FirstOrDefault(z => z.Id == x.JedinicaMereId) != null)
                .WithMessage("Jedinica mere mora postojati u bazi");
            RuleFor(x => x.TipProizvodaId)
                .Must((x, y) => context.TipProizvoda.FirstOrDefault(z => z.Id == x.TipProizvodaId) != null)
                 .WithMessage("Tip proizvoda mora postojati u bazi");
            RuleFor(x => x.Dobavljaci)
                .Must((x, y) => context.Dobavljac.Select(d => d.Id).ToList().Intersect(x.Dobavljaci).Any())
                .WithMessage("Dobavljac mora postojati u bazi");
            RuleFor(x => x.Pdv)
                .Must((x, y) => x.Pdv >= 0)
                .WithMessage("Pdv ne sme biti negativan broj")
                .Must((x, y) => x.Pdv <= 40)
                .WithMessage("Pdv ne sme biti veci od 40");
            RuleFor(x => x.Cena)
                .Must((x, y) => x.Cena >= 0)
                .WithMessage("Cena ne sme biti negativan broj");
            
        }

    }
}
