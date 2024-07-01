﻿using InterviewVideoStraeming.Models;
using VideoStreamingPlatformAPI.Event;
using VideoStreamingPlatformAPI.Models;
using VideoStreamingPlatformAPI.Repositories;
using VideoStreamingPlatformAPI.Repositories.ChannelRepository;

namespace VideoStreamingPlatformAPI.Services
{

    public class VideoService : IVideoService
    {
        IVideoRepository VideoRepository;
        IChannelRepository channelRepository;
        IUserRepository userRepository;

        public static event VideoUploadedEventHandler VideoUploaded;

        public VideoService(IVideoRepository VideoRepository, IChannelRepository channelRepository, IUserRepository userRepository)
        {
            this.VideoRepository = VideoRepository;
            this.channelRepository = channelRepository; 
            this.userRepository = userRepository;
        }
        public Video CreateVideo(string UserEmail, DepartmentTypeEnum DepartmentType, string Title,int channelId)
        {
           //DOUBT:::Need to validate the UserType, if they can create video or not? Or Can this be handled in UI itself?
           
            
            var video = VideoRepository.CreateVideo(UserEmail, DepartmentType, Title, channelId);
            //NotifySubscribers(channelId, Title, UserEmail);
            OnVideoUploaded(channelId, Title, UserEmail);
            return video;
        }

        //private void NotifySubscribers(int channelId, string title, string userEmail)
        //{
        //    var channel = channelRepository.GetChannelById(channelId);
        //    foreach (var subscriber in channel.Subscribers) 
        //    {
        //        subscriber.ReceiveNotification(channel.Name, title);

        //    }
        //}

        private void OnVideoUploaded(int channelId, string title, string email)
        {
            var channel = channelRepository.GetChannelById(channelId);
            if (VideoUploaded != null)
            {
                VideoUploaded(this, new VideoEventArgs(title, email, channel.Name));
            }
        }
    }
}
