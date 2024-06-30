using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStreamingPlatformAPI.Models;

namespace InterviewVideoStraeming.Models
{
    
    public class Channel : BaseModel
    {        
        public string Name { get; set; }
        public Department Department { get; set; }
        public List<Video> Videos { get; set; } 
        public List<User> Subscribers { get; set; } 
        public User CreatedBy { get; set; }

        
    }
}
