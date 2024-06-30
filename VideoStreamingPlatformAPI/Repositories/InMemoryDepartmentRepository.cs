using InterviewVideoStraeming.Models;

namespace VideoStreamingPlatformAPI.Repositories
{
    public class InMemoryDepartmentRepository : IDepartmentRepository
    {
        static List<Department> departmentList = new List<Department>();
        static Dictionary<int,Department> Departments = new Dictionary<int,Department>();
        static int userId = 0;
        public Department CreateDepartment(string name, DepartmentTypeEnum type)
        {
            userId++;
            Department department = new Department();
            department.Name = name;
            department.DepartmentTypeEnum = type;
            department.Id = userId;

            departmentList.Add(department);
            Departments.Add(userId, department);

            return department;

        }

        public Department GetDepartmentById(int departmentId)
        {
            return Departments[departmentId];   
        }

        public Department GetDepartmentByType(DepartmentTypeEnum departmentType) 
        {
            foreach (var department in departmentList)
            {
                if(department.DepartmentTypeEnum == departmentType) 
                    return department;
            }
            return null!;
        }
    }
}
