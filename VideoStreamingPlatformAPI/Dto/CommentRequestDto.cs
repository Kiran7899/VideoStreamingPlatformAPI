namespace VideoStreamingPlatformAPI.Dto
{
    public class CommentRequestDto
    {
        public int VideoID {  get; set; }   
        public string Comment { get; set; }
        public string UserEmail { get; set; }
    }
}
