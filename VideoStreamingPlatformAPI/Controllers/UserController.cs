using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VideoStreamingPlatformAPI.Dto;
using VideoStreamingPlatformAPI.Services;

namespace VideoStreamingPlatformAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserService userService;
        public UserController(IUserService userService)
        {
                this.userService = userService;
        }
        [HttpPost]
        public RegisterUserResponseDto RegisterUser(RegisterUserRequestDto request)
        {
            var userRegistrationResponse = userService.RegisterUser(request.UserName,request.Email,request.Password,request.DepartmentType,request.Role);
            RegisterUserResponseDto registerUserResponseDto = new RegisterUserResponseDto();
            registerUserResponseDto.ID = userRegistrationResponse.Id;
            registerUserResponseDto.DepartmentType = userRegistrationResponse.Department.DepartmentTypeEnum;
            return registerUserResponseDto;
        }

        [HttpGet]
        public LoginUserResponseDto Login(string userName,string passWord)
        {
            var loginResponse = userService.Login(userName, passWord);
            LoginUserResponseDto loginUserResponseDto = new LoginUserResponseDto();
            loginUserResponseDto.ResponseMessage = loginResponse;
            return loginUserResponseDto;  
        }

        
    }
}
