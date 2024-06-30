using InterviewVideoStraeming.Models;

namespace VideoStreamingPlatformAPI.Services
{
    public interface IDepartmentService
    {
        Department CreateDepartment(string name,DepartmentTypeEnum type);
    }
}
