using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VideoStreamingPlatformAPI.Dto;
using VideoStreamingPlatformAPI.Logger;
using VideoStreamingPlatformAPI.Services;

namespace VideoStreamingPlatformAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoController : ControllerBase
    {
        IVideoService VideoService;
        ILoggerVideoStreamingAPI _logger;
        public VideoController(IVideoService VideoService, ILoggerVideoStreamingAPI _logger)
        {
            this.VideoService = VideoService;
            this._logger = _logger;
        }

        [HttpPost]
        public ActionResult<CreateVideoResponseDto> CreateVideo(CreateVideoRequestDto createVideoRequestDto)
        {
            try
            {
                var response = VideoService.CreateVideo(createVideoRequestDto.UserEmail, createVideoRequestDto.DepartmentType, createVideoRequestDto.VideoTitle, createVideoRequestDto.ChannelID);
                CreateVideoResponseDto createVideoResponseDto = new CreateVideoResponseDto();
                createVideoResponseDto.CreatorEmail = response.UploadedBy.Email;
                createVideoResponseDto.ChannelName = response.UploadedChannel.Name;
                createVideoResponseDto.VideoID = response.Id;
                _logger.Info($"Video created with title {createVideoResponseDto.VideoTitle} is created");
                return Ok(createVideoResponseDto);
            }
            catch (Exception ex) 
            {
                _logger.Error($"Exception occured during Creating a Video",ex);
                return StatusCode(500); 
            }
        }
    }
}
