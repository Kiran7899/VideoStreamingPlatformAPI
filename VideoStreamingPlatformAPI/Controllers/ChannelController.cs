using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VideoStreamingPlatformAPI.Dto;
using VideoStreamingPlatformAPI.Logger;
using VideoStreamingPlatformAPI.Services;

namespace VideoStreamingPlatformAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChannelController : ControllerBase
    {
        IChannelService channelService;
        ILoggerVideoStreamingAPI logger;

        public ChannelController(IChannelService channel, ILoggerVideoStreamingAPI logger)
        {
            this.channelService = channel;
            this.logger = logger;
        }

        [HttpPost]
        public ActionResult<CreateChannelResponseDto> Create(CreateChannelRequestDto createChannelRequestDto)
        {
            try
            {
                var response = channelService.CreateChannel(createChannelRequestDto.DepartmentId, createChannelRequestDto.ChannelName, createChannelRequestDto.CreatorEmail);

                CreateChannelResponseDto createChannelResponseDto = new CreateChannelResponseDto();
                createChannelResponseDto.ChannelName = response.Name;
                createChannelResponseDto.ChannelId = response.Id;
                createChannelResponseDto.DepartmentName = response.Department.Name;

                return Ok(createChannelResponseDto);
            }
            catch (Exception ex)
            {
                logger.Error("Error occured while creating a Channel", ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
