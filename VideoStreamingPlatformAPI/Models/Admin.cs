using InterviewVideoStraeming.Models;
using VideoStreamingPlatformAPI.Repositories;

namespace VideoStreamingPlatformAPI.Models
{
    public class Admin : User, IVideoCreator
    {
        
        public Admin()
        {
            
        }
        public void CreateAndUploadVideo()
        {
            throw new NotImplementedException();
        }
    }
}
