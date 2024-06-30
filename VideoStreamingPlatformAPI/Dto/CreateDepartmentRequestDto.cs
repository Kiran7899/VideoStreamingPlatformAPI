using InterviewVideoStraeming.Models;

namespace VideoStreamingPlatformAPI.Dto
{
    public class CreateDepartmentRequestDto
    {
        public string DepartmentName {  get; set; }   
        public DepartmentTypeEnum DepartmentType { get; set; }  
    }
}
