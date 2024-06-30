using InterviewVideoStraeming.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using VideoStreamingPlatformAPI.Controllers;
using VideoStreamingPlatformAPI.Dto;
using VideoStreamingPlatformAPI.Logger;
using VideoStreamingPlatformAPI.Services;

namespace VideoStreaming.UnitTest
{
    [TestFixture]
    public class DepartmentControllerTests
    {
        [Test]
        public void CreateDepartment_ValidRequestObject_ShouldCreateADepartment()
        {
            //Arrang
            CreateDepartmentRequestDto requestDto = new CreateDepartmentRequestDto();
            requestDto.DepartmentName = "MR";
            requestDto.DepartmentType = InterviewVideoStraeming.Models.DepartmentTypeEnum.MR_DEVELOPMENT;
            var departmentService = new Mock<IDepartmentService>();
            var loggerService = new Mock<ILoggerVideoStreamingAPI>();
            Department department = new Department();
            department.Name = "MR";
            departmentService.Setup(Dp => Dp.CreateDepartment(It.IsAny<string>(),It.IsAny<DepartmentTypeEnum>())).Returns(department);
            DepartmentController departmentController = new DepartmentController(departmentService.Object, loggerService.Object);

            //Act
            var result = departmentController.CreateDepartment(requestDto);

            

            //Assert
            //Assert.That(result.);

        }
    }
}
