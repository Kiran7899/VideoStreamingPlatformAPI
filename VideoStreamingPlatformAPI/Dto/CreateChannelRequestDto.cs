namespace VideoStreamingPlatformAPI.Dto
{
    public class CreateChannelRequestDto
    {
        public int DepartmentId { get; set; }
        public string ChannelName { get; set;}
        public string CreatorEmail { get; set;}
    }
}
