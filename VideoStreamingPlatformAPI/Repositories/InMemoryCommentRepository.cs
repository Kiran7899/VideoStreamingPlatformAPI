using InterviewVideoStraeming.Models;

namespace VideoStreamingPlatformAPI.Repositories
{

    public class InMemoryCommentRepository : ICommentRepository
    {
        IVideoRepository videoRepository;
        static List<Comment> Comments = new List<Comment>();
        static Dictionary<int,Comment> CommentMapByID = new Dictionary<int,Comment>();
        int commentId = 0;
        public InMemoryCommentRepository(IVideoRepository videoRepository)
        {
            this.videoRepository = videoRepository;
        }
        static List<Comment> comments = new List<Comment>();
        public bool AddComment(int videoId, string comment)
        {
            Video video = videoRepository.GetVideoByID(videoId);
            if(video != null)
            {
                commentId++;
                Comment commentObj = new Comment();
                commentObj.Video = video;
                commentObj.Message = comment;
                commentObj.Id = commentId;

                comments.Add(commentObj);
                CommentMapByID.Add(commentId,commentObj);
                return true;
            }

            return false;
        }
    }
}
