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

        bool Comment(int videoId, string comment,string userEmail);

        bool Like(int videoId, string userEmail);
        
    }
}
