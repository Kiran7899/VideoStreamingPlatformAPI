using InterviewVideoStraeming.Models;

namespace VideoStreamingPlatformAPI.Repositories
{
    public interface IDepartmentRepository
    {
        Department CreateDepartment(string name, DepartmentTypeEnum type);
        Department GetDepartmentById(int departmentId);
        Department GetDepartmentByType(DepartmentTypeEnum departmentType);
    }
}
