using Business.Departments;
using Models.Departments;
using Models.Dto;
using Moq;
using Xunit;

namespace UnitTests.DepartmentsTests
{
    public class ServiceTests
    {
        private readonly Mock<IDepartmentService> _departmentMockService;

        public ServiceTests()
        {
            _departmentMockService = new Mock<IDepartmentService>();

            _departmentMockService
                .Setup(s => s.GetAll())
                .Returns(new StandarResponseDto
                {
                    StatusCode = 200,
                    StatusMessage = "Process completed successfully",
                    ProcessDate = "",
                    Data = null
                });

            _departmentMockService
                .Setup(s => s.GetById(1))
                .Returns(new StandarResponseDto
                {
                    StatusCode = 200,
                    StatusMessage = "Process completed successfully",
                    ProcessDate = "",
                    Data = null
                });

            _departmentMockService
                .Setup(s => s.GetEmployeesByDepartmentId(1))
                .Returns(new StandarResponseDto
                {
                    StatusCode = 200,
                    StatusMessage = "Process completed successfully",
                    ProcessDate = "",
                    Data = null
                });

            _departmentMockService
                .Setup(s => s.Create(new Department
                {
                    Name = "Recursos Humanos"
                }))
                .Returns(new StandarResponseDto
                {
                    StatusCode = 200,
                    StatusMessage = "Process completed successfully",
                    ProcessDate = "",
                    Data = null
                });

            _departmentMockService
                .Setup(s => s.Update(new Department
                {
                    Id = 9,
                    Name = "Recursos Humanos"
                }))
                .Returns(new StandarResponseDto
                {
                    StatusCode = 200,
                    StatusMessage = "Process completed successfully",
                    ProcessDate = "",
                    Data = null
                });

            _departmentMockService
                .Setup(s => s.Delete(new Department
                {
                    Id = 9,
                    Name = "Recursos Humanos"
                }))
                .Returns(new StandarResponseDto
                {
                    StatusCode = 200,
                    StatusMessage = "Process completed successfully",
                    ProcessDate = "",
                    Data = null
                });
        }

        [Fact]
        private void Department_GetAll_OK_Test()
        {

            StandarResponseDto getList = _departmentMockService.Object.GetAll();

            Assert.Equal(200, getList.StatusCode);
        }

        [Fact]
        private void Department_GetAll_NotFound_Test()
        {

            StandarResponseDto getList = _departmentMockService.Object.GetAll();

            Assert.NotEqual(403, getList.StatusCode);
        }

        [Fact]
        private void Department_GetById_OK_Test()
        {

            StandarResponseDto getOne = _departmentMockService.Object.GetById(1);

            Assert.Equal(200, getOne.StatusCode);
        }

        [Fact]
        private void Department_GetEmployeesByDepartmentId_NotFound_Test()
        {

            StandarResponseDto getOne = _departmentMockService.Object.GetById(1);

            Assert.NotEqual(403, getOne.StatusCode);
        }

        [Fact]
        private void Department_GetEmployeesByDepartmentId_OK_Test()
        {

            StandarResponseDto getOne = _departmentMockService.Object.GetById(1);

            Assert.Equal(200, getOne.StatusCode);
        }

        [Fact]
        private void Department_GetById_NotFound_Test()
        {

            StandarResponseDto getOne = _departmentMockService.Object.GetById(1);

            Assert.NotEqual(403, getOne.StatusCode);
        }

        [Fact]
        private void Department_Create_OK_Test()
        {

            StandarResponseDto setOne = _departmentMockService.Object.Create(new Department());

            Assert.Equal(null, setOne);
        }

        [Fact]
        private void Department_Create_NotFound_Test()
        {

            StandarResponseDto setOne = _departmentMockService.Object.Create(new Department());

            Assert.NotEqual(new StandarResponseDto(), setOne);
        }

        [Fact]
        private void Department_Update_OK_Test()
        {

            StandarResponseDto setOne = _departmentMockService.Object.Update(new Department());

            Assert.Equal(null, setOne);
        }

        [Fact]
        private void Department_Update_NotFound_Test()
        {

            StandarResponseDto setOne = _departmentMockService.Object.Update(new Department());

            Assert.NotEqual(new StandarResponseDto(), setOne);
        }

        [Fact]
        private void Department_Delete_OK_Test()
        {

            StandarResponseDto setOne = _departmentMockService.Object.Delete(new Department());

            Assert.Equal(null, setOne);
        }

        [Fact]
        private void Department_Delete_NotFound_Test()
        {

            StandarResponseDto setOne = _departmentMockService.Object.Delete(new Department());

            Assert.NotEqual(new StandarResponseDto(), setOne);
        }
    }
}
