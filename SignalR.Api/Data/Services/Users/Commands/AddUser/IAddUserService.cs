using SignalR.Api.Data.Contexts;
using SignalR.Api.Model.Commons;
using SignalR.Api.Model.Entities;

namespace SignalR.Api.Data.Services.Users.Commands.AddUser
{
    public interface IAddUserService
    {
        Task<ResultDto> ExecuteAsync(AddUserDto userDto);
    }

    public class AddUserService : IAddUserService
    {
        private readonly DatabaseContext _context;
        public AddUserService(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<ResultDto> ExecuteAsync(AddUserDto userDto)
        {
            if (string.IsNullOrWhiteSpace(userDto.Mobile) ||
                string.IsNullOrWhiteSpace(userDto.Password))
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "لطفا اطلاعات ضروری را تکمیل کنید"
                };
            }

            User user = new User
            {
                UserName = userDto.Mobile,
                Password = userDto.Password,
            };

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return new ResultDto
            {
                IsSuccess = true,
                Message = "کاربر با موفقیت افزوده شد"
            };
        }
    }

    public class AddUserDto
    {
        //public string? FirstName { get; set; }
        //public string? LastName { get; set; }
        public string? Mobile { get; set; }
        public string? Password { get; set; }
    }
}
