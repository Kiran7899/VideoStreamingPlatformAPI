using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStreamingPlatformAPI.Event;
using VideoStreamingPlatformAPI.Models;
using VideoStreamingPlatformAPI.Repositories;

namespace InterviewVideoStraeming.Models
{
    public class User : BaseModel
    {
        ICommentRepository commentRepository; 
        ILikeRepository likeRepository;
        public User()
        {

        }
        public User(ICommentRepository commentRepository, ILikeRepository likeRepository)
        {
            this.commentRepository = commentRepository;
            this.likeRepository = likeRepository;
        }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public Department Department { get; set; }
        public UserTypeEnum UserType { get; set; }
        public List<Channel> SubscribedChannels { get; set; }

        public bool LikeVideo(int videoId) 
        {
            return likeRepository.AddLike(videoId);
        }
        public bool CommentOnVideo(int videoId, string comment) 
        {
            return commentRepository.AddComment(videoId, comment);
        }




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
