using InterviewVideoStraeming.Models;

namespace VideoStreamingPlatformAPI.Repositories
{
    public interface IUserRepository
    {
        User RegisterUser(string username,
            string email,
            string password,
            DepartmentTypeEnum department,
            UserTypeEnum role);

        List<User> GetUsers();

        User GetUserByEmail(string email);
    }
}
