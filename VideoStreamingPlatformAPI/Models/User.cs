using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStreamingPlatformAPI.Event;
using VideoStreamingPlatformAPI.Models;

namespace InterviewVideoStraeming.Models
{
    public class User : BaseModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public Department Department { get; set; }
        public UserTypeEnum UserType { get; set; }
        public List<Channel> SubscribedChannels { get; set; }

        public void LikeVideo() { }
        public void CommentOnVideo() { }


        public void ReceiveNotification(string channelName, string videoTitle)
        {
            Console.WriteLine($"Hi {this.UserName}, New video {videoTitle} is uploaded in {channelName}");
        }

        public void ReceiveNotificationFromSubscribedChannels(object sender, VideoEventArgs videoEventArgs)
        {
            Console.WriteLine($"Hi {UserName} !!! New video {videoEventArgs.Title} is uploaded in {videoEventArgs.ChannelName}");
        }

    }
}
