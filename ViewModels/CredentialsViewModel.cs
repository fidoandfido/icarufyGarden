using IcarufyGarden.ViewModels.Validations;
using FluentValidation.Attributes;


namespace IcarufyGarden.Controllers
{
    [Validator(typeof(CredentialsViewModelValidator))]
    public class CredentialsViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
