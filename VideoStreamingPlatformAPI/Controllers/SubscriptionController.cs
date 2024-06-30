using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VideoStreamingPlatformAPI.Dto;
using VideoStreamingPlatformAPI.Logger;
using VideoStreamingPlatformAPI.Services;

namespace VideoStreamingPlatformAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionController : ControllerBase
    {
        ISubscribeService _subscribeService;
        ILoggerVideoStreamingAPI _logger;
        public SubscriptionController(ISubscribeService _subscribeService, ILoggerVideoStreamingAPI _logger)
        {
            this._subscribeService = _subscribeService;
            this._logger = _logger;
        }
        [HttpPost]
        public void Subscribe(SubscribeResponseDto request)
        {
            try
            {
                _subscribeService.Subscribe(request.UserEmail, request.channelId);
                _logger.Info($"{request.UserEmail} successfully subscribed");
            }
            catch (Exception ex)
            {
                _logger.Error("Error occurred while subscribing a channel", ex);
            }
        }

        [HttpPost("UnSubscribe")]
        public void UnSubscribe(UnsubscribeRequestDto requestDto)
        {
            try
            {
                _subscribeService.UnSubscribe(requestDto.UserEmail, requestDto.ChannelId);
                _logger.Info($"{requestDto.UserEmail} successfully UnSubscribed");
            }
            catch (Exception ex) 
            {
                _logger.Error("Error occured while un subscribing a channel", ex);
            }
        }
    }
}
