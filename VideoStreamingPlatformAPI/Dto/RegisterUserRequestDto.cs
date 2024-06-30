using InterviewVideoStraeming.Models;

namespace VideoStreamingPlatformAPI.Dto
{
    public class RegisterUserRequestDto

    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public string Email { get; set; }
        public DepartmentTypeEnum DepartmentType { get; set; }
        public UserTypeEnum Role { get; set; }
    }
}
