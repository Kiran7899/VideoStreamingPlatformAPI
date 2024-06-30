using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VideoStreamingPlatformAPI.Dto;
using VideoStreamingPlatformAPI.Services;

namespace VideoStreamingPlatformAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoController : ControllerBase
    {
        IVideoService VideoService;
        public VideoController(IVideoService VideoService)
        {
            this.VideoService = VideoService;
        }

        [HttpPost]
        public CreateVideoResponseDto CreateVideo(CreateVideoRequestDto createVideoRequestDto)
        {
            var response = VideoService.CreateVideo(createVideoRequestDto.UserEmail, createVideoRequestDto.DepartmentType, createVideoRequestDto.VideoTitle, createVideoRequestDto.ChannelID);
            CreateVideoResponseDto createVideoResponseDto = new CreateVideoResponseDto();
            createVideoResponseDto.CreatorEmail = response.UploadedBy.Email;
            createVideoResponseDto.ChannelName = response.UploadedChannel.Name;
            createVideoResponseDto.VideoID = response.Id;

            return createVideoResponseDto;  
        }
    }
}
