using Entities.Concrete.Models;
using FluentValidation;

namespace Business.Validations
{
    public class CarValidation : AbstractValidator<Car>
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

            RuleFor(x => x.CarModel)
               .MinimumLength(2)
               .WithMessage("2 simvoldan az daxil etmək olmaz")
               .MaximumLength(50)
               .WithMessage("50 simvoldan yuxarı daxil etmək olmaz")
               .NotEmpty()
               .WithMessage("Boş ola bilməz");

            RuleFor(x => x.CarCondition)
               .MinimumLength(2)
               .WithMessage("2 simvoldan az daxil etmək olmaz")
               .MaximumLength(100)
               .NotEmpty()
               .WithMessage("Boş ola bilməz");

            RuleFor(x => x.CarPrice)
               .Must(MinimumPrice)
               .WithMessage("2 simvoldan az daxil etmək olmaz")
               .NotEmpty()
               .WithMessage("Boş ola bilməz");

            RuleFor(x => x.CarYear)
               .NotEmpty()
               .WithMessage("Boş ola bilməz");

            RuleFor(x => x.CarPhotoUrl)
               .NotEmpty()
               .WithMessage("Boş ola bilməz");

            RuleFor(x => x.BranId)
               .NotEmpty()
               .WithMessage("Boş ola bilməz");
            
            RuleFor(x => x.CarBodyId)
               .NotEmpty()
               .WithMessage("Boş ola bilməz");
        }

        private bool MinimumPrice(decimal price)
        {
            if (price > 100)
                return true;
            return false;
        }
    }
}
