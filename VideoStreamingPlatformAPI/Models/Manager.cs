using InterviewVideoStraeming.Models;
using VideoStreamingPlatformAPI.Repositories;

namespace VideoStreamingPlatformAPI.Models
{
    public class Manager : User, IVideoCreator
    {
       
       
        public Manager()
        {
            
        }
        public void CreateAndUploadVideo()
        {
            throw new NotImplementedException();
        }
    }
}
