
using System.Threading.Tasks;
using AutoMapper;
using IcarufyGarden.Data;
using IcarufyGarden.Models.Entities;
using IcarufyGarden.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IcarufyGarden.Controllers
{
    [Produces("application/json")]
    [Route("api/Accounts")]
    public class AccountsController : Controller
    {
        private readonly ApplicationDbContext applicationDbContext;
        private readonly UserManager<AppUser> userManager;
        private readonly IMapper mapper;


        public AccountsController(UserManager<AppUser> userManager, IMapper mapper, ApplicationDbContext applicationDbContext)
        {
            this.userManager = userManager;
            this.mapper = mapper;
            this.applicationDbContext = applicationDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]RegistrationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userIdentity = mapper.Map<AppUser>(model);
            var result = await userManager.CreateAsync(userIdentity, model.Password);

            if (!result.Succeeded)
            {
                foreach (var e in result.Errors)
                {
                    ModelState.TryAddModelError(e.Code, e.Description);
                }
                return new BadRequestObjectResult(ModelState);
            }

            await applicationDbContext.SaveChangesAsync();
            return new OkResult();
        }

    }
}
