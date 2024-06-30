using InterviewVideoStraeming.Models;

namespace VideoStreamingPlatformAPI.Services
{
    public interface IUserService
    {
        User RegisterUser(
            string username,
            string email,
            string password,
            DepartmentTypeEnum department,
            UserTypeEnum role);

        string Login(string userName, string password);
        
    }
}
