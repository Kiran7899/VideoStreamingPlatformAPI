using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VideoStreamingPlatformAPI.Dto;
using VideoStreamingPlatformAPI.Services;

namespace VideoStreamingPlatformAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChannelController : ControllerBase
    {
        IChannelService channelService;

        public ChannelController(IChannelService channel)
        {
             this.channelService = channel;
        }

        [HttpPost]
        public CreateChannelResponseDto Create(CreateChannelRequestDto createChannelRequestDto)
        {
            var response = channelService.CreateChannel(createChannelRequestDto.DepartmentId, createChannelRequestDto.ChannelName, createChannelRequestDto.CreatorEmail);

            CreateChannelResponseDto createChannelResponseDto = new CreateChannelResponseDto();
            createChannelResponseDto.ChannelName = response.Name;
            createChannelResponseDto.ChannelId = response.Id;
            createChannelResponseDto.DepartmentName = response.Department.Name;

            return createChannelResponseDto;
        }
    }
}
