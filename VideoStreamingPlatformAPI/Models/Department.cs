using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStreamingPlatformAPI.Models;

namespace InterviewVideoStraeming.Models
{
    public class Department : BaseModel
    {
        public string Name { get; set; }    
        public DepartmentTypeEnum DepartmentTypeEnum { get; set; }
    }
}
