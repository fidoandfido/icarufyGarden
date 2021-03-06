using FluentValidation;

namespace IcarufyGarden.ViewModels.Validations
{
    public class GardenBedModelValidator: AbstractValidator<RegistrationViewModel>
    {
        public GardenBedModelValidator()
        {
            RuleFor(vm => vm.Email).NotEmpty().WithMessage("Email cannot be empty");
            RuleFor(vm => vm.Password).NotEmpty().WithMessage("Password cannot be empty");
            RuleFor(vm => vm.FirstName).NotEmpty().WithMessage("FirstName cannot be empty");
            RuleFor(vm => vm.LastName).NotEmpty().WithMessage("LastName cannot be empty");
        }
    }
}
