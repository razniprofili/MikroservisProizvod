using Domen;
using FluentValidation;
using MikroServisProizvod.Application.IServices.ProizvodServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikroServisProizvod.Implementation.ServiceImplementations.Proizvod
{
    public class ProizvodValidator : AbstractValidator<ProizvodDto>
    {
        public ProizvodValidator(Context context)
        {

            RuleFor(x => x)
                .Cascade(CascadeMode.Stop) // cim naidje na prvu gresku, stace i obavestiti klijenta
                 .Must(x => !String.IsNullOrEmpty(x.Naziv))
                    .WithMessage("Naziv ne sme biti prazan.")
                .Must(x => context.JedinicaMere.FirstOrDefault(z => z.Id == x.JedinicaMereId) != null)
                    .WithMessage("Jedinica mere mora postojati u bazi")
                .Must(x => context.TipProizvoda.FirstOrDefault(z => z.Id == x.TipProizvodaId) != null)
                    .WithMessage("Tip proizvoda mora postojati u bazi")
                .Must( x => context.Dobavljac.Select( d => d.Id).ToList().Intersect(x.DobavljaciIds).Any())
                    .WithMessage("Dobavljac mora postojati u bazi")
                .Must(x => x.Pdv >= 0)
                    .WithMessage("Pdv ne sme biti negativan broj")
                .Must(x => x.Pdv <= 40)
                    .WithMessage("Pdv ne sme biti veci od 40")
                .Must(x => x.Cena >= 0)
                    .WithMessage("Cena ne sme biti negativan broj")

            ;
            //RuleFor(x => x.Naziv)
            //    .NotEmpty()
            //    .WithMessage("Naziv ne sme biti prazan.");
            //RuleFor(x => x.JedinicaMere)
            //    .Must(x => context.JedinicaMere.FirstOrDefault(z => z.Id == x.Id) != null)
            //    .WithMessage("Jedinica mere mora postojati u bazi");
            //RuleFor(x => x.TipProizvoda)
            //    .Must(x => context.TipProizvoda.FirstOrDefault(z => z.Id == x.Id) != null)
            //    .WithMessage("Tip proizvoda mora postojati u bazi");
            //RuleFor(x => x.Dobavljac)
            //    .Must(x => context.Dobavljac.FirstOrDefault(z => z.Id == x.Id) != null)
            //    .WithMessage("Dobavljac mora postojati u bazi");
            //RuleFor(x => x.Pdv)
            //    .GreaterThanOrEqualTo(0)
            //    .WithMessage("Pdv ne sme biti negativan broj")
            //    .LessThanOrEqualTo(40)
            //    .WithMessage("Pdv ne sme biti veci od 40");
            //RuleFor(x => x.Cena)
            //    .GreaterThanOrEqualTo(0)
            //    .WithMessage("Cena ne sme biti negativan broj");
        }

    }
}
