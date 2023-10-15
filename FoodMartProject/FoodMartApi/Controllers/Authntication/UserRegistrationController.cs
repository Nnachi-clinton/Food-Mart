using FoodMartCore.IServices;
using FoodMartDomain.ViewModels.RequestModel;
using Microsoft.AspNetCore.Mvc;

namespace FoodMartApi.Controllers.Authntication
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRegistrationController : ControllerBase
    {
        private readonly IUserRegistrationService _userRegistrationService;

        public UserRegistrationController(IUserRegistrationService userRegistrationService)
        {
            _userRegistrationService = userRegistrationService;
        }

        [HttpPost("Create-User")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterRequestViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _userRegistrationService.CreateUserAsync(model, ModelState);

            if (result != null) 
              return Ok(result);            
            else            
              return BadRequest(ModelState);
            
        }


        [HttpPost("Create-Vendor")]
        public async Task<IActionResult> RegisterVendor([FromBody] RegisterRequestViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _userRegistrationService.CreateVendorAsync(model, ModelState);

            if (result != null)
                return Ok(result);
            else
                return BadRequest(ModelState);

        }
    }
}
