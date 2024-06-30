using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VideoStreamingPlatformAPI.Dto;
using VideoStreamingPlatformAPI.Services;

namespace VideoStreamingPlatformAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService DepartmentService)
        {
            this._departmentService = DepartmentService;
        }
        [HttpPost]
        public CreateDepartmentResponseDto CreateDepartment(CreateDepartmentRequestDto requestDto)
        {
            var response = _departmentService.CreateDepartment(requestDto.DepartmentName, requestDto.DepartmentType);
            CreateDepartmentResponseDto createDepartmentResponseDto = new CreateDepartmentResponseDto();
            createDepartmentResponseDto.DepartmentName = response.Name;
            return createDepartmentResponseDto;
        }

    }
}
