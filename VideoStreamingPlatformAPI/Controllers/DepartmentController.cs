using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VideoStreamingPlatformAPI.Dto;
using VideoStreamingPlatformAPI.Logger;
using VideoStreamingPlatformAPI.Services;

namespace VideoStreamingPlatformAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        IDepartmentService _departmentService;
        ILoggerVideoStreamingAPI _logger;
        public DepartmentController(IDepartmentService DepartmentService, ILoggerVideoStreamingAPI loggerVideoStreamingAPI)
        {
            this._departmentService = DepartmentService;
            this._logger = loggerVideoStreamingAPI;
        }
        [HttpPost]
        public ActionResult<CreateDepartmentResponseDto> CreateDepartment(CreateDepartmentRequestDto requestDto)
        {
            try
            {
                var response = _departmentService.CreateDepartment(requestDto.DepartmentName, requestDto.DepartmentType);
                CreateDepartmentResponseDto createDepartmentResponseDto = new CreateDepartmentResponseDto();
                createDepartmentResponseDto.DepartmentName = response.Name;
                return Ok(createDepartmentResponseDto);
            }
            catch (Exception ex) 
            {
                _logger.Error("Error occured while creating a Department", ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

    }
}
