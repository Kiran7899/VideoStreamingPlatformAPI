using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStreamingPlatformAPI.Models;

namespace InterviewVideoStraeming.Models
{
    public class Comment : BaseModel
    {        
        public string Message {  get; set; }
        public User User { get; set; }

    }
}
