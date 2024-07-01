namespace VideoStreamingPlatformAPI.Repositories
{
    public interface ICommentRepository
    {
        bool AddComment(int videoId, string comment);
    }
}
