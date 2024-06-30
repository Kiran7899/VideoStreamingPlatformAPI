namespace VideoStreamingPlatformAPI.Dto
{
    public class CreateVideoResponseDto
    {
        public int VideoID {  get; set; }
        public string ChannelName { get; set; }
        public string CreatorEmail {  get; set; }
        public string VideoTitle { get; set; }
    }
}
