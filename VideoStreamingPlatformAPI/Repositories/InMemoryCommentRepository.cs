using InterviewVideoStraeming.Models;

namespace VideoStreamingPlatformAPI.Repositories
{

    public class InMemoryCommentRepository : ICommentRepository
    {
        IVideoRepository videoRepository;
        IUserRepository userRepository;
        static List<Comment> Comments = new List<Comment>();
        static Dictionary<int,Comment> CommentMapByID = new Dictionary<int,Comment>();
        static int commentId = 0;
        public InMemoryCommentRepository(IVideoRepository videoRepository, IUserRepository userRepository)
        {
            this.videoRepository = videoRepository;
            this.userRepository = userRepository;
        }
        static List<Comment> comments = new List<Comment>();
        public bool AddComment(int videoId, string comment,string userEmail)
        {
            Video video = videoRepository.GetVideoByID(videoId);
            User user = userRepository.GetUserByEmail(userEmail);
            if(video != null && user != null)
            {
                commentId++;
                Comment commentObj = new Comment();
                //commentObj.Video = video;
                commentObj.Message = comment;
                commentObj.Id = commentId;
                commentObj.User = user;
                video.comments.Add(commentObj);

                comments.Add(commentObj);
                CommentMapByID.Add(commentId,commentObj);
                return true;
            }

            return false;
        }
    }
}
