using FoodMartCore.IServices;
using FoodMartDomain.ViewModels.RequestModel;
using Microsoft.AspNetCore.Mvc;

namespace FoodMartApi.Controllers.Authntication
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLoginController : ControllerBase
    {
        private readonly IUserLoginService _userLoginService;
        

        public UserLoginController(IUserLoginService userLoginService)
        {
            _userLoginService = userLoginService;
          
        }

        [HttpPost("login")]

        public async Task<IActionResult> Login([FromBody] LoginRequestViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _userLoginService.FindUserByEmailAsync(model);
            return Ok(response);


        }
    }
}
