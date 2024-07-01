using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VideoStreamingPlatformAPI.Dto;
using VideoStreamingPlatformAPI.Logger;
using VideoStreamingPlatformAPI.Services;

namespace VideoStreamingPlatformAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserService userService;
        ILoggerVideoStreamingAPI _logger;
        public UserController(IUserService userService, ILoggerVideoStreamingAPI _logger)
        {
            this.userService = userService;
            this._logger = _logger;
        }
        [HttpPost]
        public ActionResult<RegisterUserResponseDto> RegisterUser(RegisterUserRequestDto request)
        {
            try
            {
                var userRegistrationResponse = userService.RegisterUser(request.UserName, request.Email, request.Password, request.DepartmentType, request.Role);
                RegisterUserResponseDto registerUserResponseDto = new RegisterUserResponseDto();
                registerUserResponseDto.ID = userRegistrationResponse.Id;
                registerUserResponseDto.DepartmentType = userRegistrationResponse.Department.DepartmentTypeEnum;
                _logger.Info($"{request.UserName} is registered successfully");
                return Ok(registerUserResponseDto);
            }
            catch (Exception ex) 
            {
                _logger.Error($"Error occured during creating User",ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        public ActionResult<LoginUserResponseDto> Login(string userName, string passWord)
        {
            try
            {
                var loginResponse = userService.Login(userName, passWord);
                LoginUserResponseDto loginUserResponseDto = new LoginUserResponseDto();
                loginUserResponseDto.ResponseMessage = loginResponse;
                return Ok(loginUserResponseDto);
            }
            catch (Exception ex)
            {
                _logger.Error($"Error occured during creating User", ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost("Comment")]
        public ActionResult<CommentResponseDto> Comment(CommentRequestDto commentRequestDto)
        {
            try
            {
                var isCommentAdded = userService.Comment(commentRequestDto.VideoID, commentRequestDto.Comment, commentRequestDto.UserEmail);
                CommentResponseDto commentResponseDto = new CommentResponseDto();
                commentResponseDto.IsSuccessfullyCommented = isCommentAdded;
                _logger.Info($"{commentRequestDto.UserEmail}'s Comment is successfully added");
                return Ok(commentResponseDto);
            }
            catch(Exception ex)
            {
                _logger.Error($"Error occurred while adding the comment",ex);
                return StatusCode(500);
            }
        }

        [HttpPost("Like")]
        public ActionResult<LikeResponseDto> Like(LikeRequestDto likeRequestDto)
        {
            return null!;
        }


    }
}
