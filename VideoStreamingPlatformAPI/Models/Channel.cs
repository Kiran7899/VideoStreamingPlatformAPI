using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStreamingPlatformAPI.Event;
using VideoStreamingPlatformAPI.Models;
using VideoStreamingPlatformAPI.Repositories.ChannelRepository;

namespace InterviewVideoStraeming.Models
{
    
    public class Channel : BaseModel
    {
        public event VideoUploadedEventHandler VideoUploaded;

        public string Name { get; set; }
        public Department Department { get; set; }
        public List<Video> Videos { get; set; } 
        public List<User> Subscribers { get; set; } 
        public User CreatedBy { get; set; }

        public Channel()
        {
            Videos = new List<Video>();
            Subscribers = new List<User>();
        }

        public void NotifySubscribers(Video video)
        {
            
            Videos.Add(video);
            if (VideoUploaded != null) 
            {
                VideoUploaded.Invoke(this, new VideoEventArgs(video.Title, video.UploadedBy.Email, Name));
            }
        }

        
    }
}
