using InterviewVideoStraeming.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStreamingPlatformAPI.Repositories;
using VideoStreamingPlatformAPI.Services;

namespace VideoStreaming.UnitTest.Services
{
    public class DepartmentServiceTests
    {
        private DepartmentService GetDepartmentService(IDepartmentRepository DepartmentRepository)
        {
            return new DepartmentService(DepartmentRepository);
        }

        [Test]
        public void CreateDepartment_ValidInput_ReturnValidDepartment()
        {
            var departmentRepository = new Mock<IDepartmentRepository>();
            departmentRepository.Setup(dep => dep.CreateDepartment(It.IsAny<string>(), It.IsAny<DepartmentTypeEnum>())).Returns(new Department());
            var departmentService = GetDepartmentService(departmentRepository.Object);

            var result = departmentService.CreateDepartment("DX", DepartmentTypeEnum.DX_ADMIN);

            Assert.IsNotNull(result);
        }
    }
}
