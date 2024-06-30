using InterviewVideoStraeming.Models;

namespace VideoStreamingPlatformAPI.Models
{
    public class Admin : User, IVideoCreator
    {
        public void CreateAndUploadVideo()
        {
            throw new NotImplementedException();
        }
    }
}
