using FluentValidation;
using IcarufyGarden.Models.Entities;

namespace IcarufyGarden.Models.Validations
{
    public class GardenBedModelValidator: AbstractValidator<GardenBed>
    {
        public GardenBedModelValidator()
        {
            RuleFor(gb => gb.Description).NotEmpty().WithMessage("Description cannot be empty");
        }
    }
}
