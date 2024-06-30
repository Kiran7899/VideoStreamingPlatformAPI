using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStreamingPlatformAPI.Models;

namespace InterviewVideoStraeming.Models
{
    public class User : BaseModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }   
        public Department Department { get;set; }
        public UserTypeEnum UserType { get; set; }  
        public List<Channel> SubscribedChannels { get; set; }

        public void LikeVideo() { }
        public void CommentOnVideo() { }
        public void SubscribeChannel() { }
       

    }
}
