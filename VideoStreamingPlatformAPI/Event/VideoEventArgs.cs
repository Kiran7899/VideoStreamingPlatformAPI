namespace VideoStreamingPlatformAPI.Event
{
    public delegate void VideoUploadedEventHandler(object sender, VideoEventArgs e);

    public class VideoEventArgs : EventArgs
    {
        public string Title { get; set; }
        public string Email { get; set; }
        public string ChannelName {  get; set; }

        public VideoEventArgs(string title, string email,string channelName)
        {
            Title = title;
            Email = email;
            ChannelName = channelName;
        }
    }

}
