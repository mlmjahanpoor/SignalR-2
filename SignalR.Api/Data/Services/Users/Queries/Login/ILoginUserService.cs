using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SignalR.Api.Data.Contexts;
using SignalR.Api.Model.Commons;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace SignalR.Api.Data.Services.Users.Queries.Login
{
    public interface ILoginUserService
    {
        Task<ResultDto<LoginResultDto>> ExecuteAsync(LoginUserDto userDto);
    }

    public class LoginUserService : ILoginUserService
    {
        private readonly DatabaseContext _context;
        public LoginUserService(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<ResultDto<LoginResultDto>> ExecuteAsync(LoginUserDto userDto)
        {
            var user = await _context.Users
                .SingleOrDefaultAsync(u => u.UserName.Equals(userDto.UserName) && u.Password.Equals(userDto.Password));

            if (user is not null)
            {
                string key = "{06F52ADB-FAD1-4745-83FE-C97F5BBF8E6E}";
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
                var credentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(

                    issuer: "test",
                    audience: "test",
                    expires: DateTime.Now.AddDays(30),
                    notBefore: DateTime.Now,
                    signingCredentials: credentials

                    );

                var x = new JwtSecurityTokenHandler().WriteToken(token);


                return new ResultDto<LoginResultDto>
                {
                    IsSuccess = true,
                    Message = "با موفقیت وارد شدید",
                    Data = new LoginResultDto
                    {
                        Token = x
                    }
                };
            }

            return new ResultDto<LoginResultDto>
            {
                IsSuccess = false,
                Message = "کاربر یافت نشد"
            };
        }
    }

    public class LoginUserDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class LoginResultDto
    {
        public string Token { get; set; }
    }
}
