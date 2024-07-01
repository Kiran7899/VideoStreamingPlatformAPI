using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStreamingPlatformAPI.Models;

namespace InterviewVideoStraeming.Models
{
    public class Video : BaseModel
    {   
        public Video() 
        {
            comments = new List<Comment>();
        }  
        public string Title { get; set; }
        public string Description { get; set; } 
        public User UploadedBy { get; set; }        
        public Channel UploadedChannel { get; set; } 
        public List<Comment> comments { get; set; }

    }
}
