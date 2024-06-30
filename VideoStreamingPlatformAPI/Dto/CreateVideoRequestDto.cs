using InterviewVideoStraeming.Models;

namespace VideoStreamingPlatformAPI.Dto
{
    public class CreateVideoRequestDto
    {
        public string UserEmail { get; set; } 
        public DepartmentTypeEnum DepartmentType{  get; set; }
        public string VideoTitle { get; set; }   
        public int ChannelID {  get; set; }        

    }
}
