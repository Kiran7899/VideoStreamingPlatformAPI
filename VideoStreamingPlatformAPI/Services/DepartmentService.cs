using InterviewVideoStraeming.Models;
using VideoStreamingPlatformAPI.Repositories;

namespace VideoStreamingPlatformAPI.Services
{
    
    public class DepartmentService : IDepartmentService
    {
        IDepartmentRepository DepartmentRepository;
        public DepartmentService(IDepartmentRepository DepartmentRepository)
        {
              this.DepartmentRepository = DepartmentRepository;
        }
        public Department CreateDepartment(string name, DepartmentTypeEnum type)
        {
            return DepartmentRepository.CreateDepartment(name, type);
        }
    }
}
