using InterviewVideoStraeming.Models;

namespace VideoStreamingPlatformAPI.Dto
{
    public class RegisterUserResponseDto
    {
        public int ID { get; set; }
        public DepartmentTypeEnum DepartmentType { get; set; }
    }
}
