using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.Api.Data.Services.Users.Commands.AddUser;
using SignalR.Api.Data.Services.Users.Queries.Login;

namespace SignalR.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAddUserService _addUserService;
        private readonly ILoginUserService _loginUserService;
        public AccountController(IAddUserService addUserService, ILoginUserService loginUserService)
        {
            _addUserService = addUserService;
            _loginUserService = loginUserService;
        }

        [HttpPost]
        public async Task<IActionResult> Register(AddUserDto userDto)
        {
            var result = await _addUserService.ExecuteAsync(userDto);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginUserDto userDto)
        {
            var result = await _loginUserService.ExecuteAsync(userDto);
            return Ok(result);
        }
    }
}
