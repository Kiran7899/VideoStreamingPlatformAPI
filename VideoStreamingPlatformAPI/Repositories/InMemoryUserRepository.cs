using InterviewVideoStraeming.Models;

namespace VideoStreamingPlatformAPI.Repositories
{
    public class InMemoryUserRepository : IUserRepository
    {
        IDepartmentRepository DepartmentRepository;
        private static Dictionary<int, User> _users = new Dictionary<int, User>();
        private static int userCount = 0;

        public InMemoryUserRepository(IDepartmentRepository DepartmentRepository)
        {
                this.DepartmentRepository = DepartmentRepository;
        }
        public User GetUserByEmail(string email)
        {
            foreach (var user in _users) 
            {
                User currentUser = user.Value;
                if(currentUser.Email.Equals(email))
                    return currentUser;
            }
            return null!;
        }

        public List<User> GetUsers()
        {
            return _users.Values.ToList();
        }

        public User RegisterUser(string username, string email, string password, DepartmentTypeEnum department, UserTypeEnum role)
        {
            userCount++;
            User user = new User();
            user.UserName = username;
            user.Email = email;
            user.Password = password;
            user.Department = DepartmentRepository.GetDepartmentByType(department);            
            user.UserType = role;
            user.Id = userCount;


            _users.Add(userCount, user);

            return user;
        }
    }
}
