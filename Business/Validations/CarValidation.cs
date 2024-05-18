using Entities.Concrete.Models;
using FluentValidation;

namespace Business.Validations
{
    public class CarValidation :AbstractValidator<Car>
    {
        public CarValidation()
        {
            RuleFor(x => x.CarHp)
               .MinimumLength(2)
               .WithMessage("2 simvoldan az daxil etmək olmaz")
               .MaximumLength(4)
               .WithMessage("4 simvoldan cox ola bilməz")
               .NotEmpty()
               .WithMessage("Boş ola bilməz");

        }
    }
}
