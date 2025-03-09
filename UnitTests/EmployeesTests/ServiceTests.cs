using Business.Employees;
using Models.Dto;
using Moq;
using Xunit;

namespace UnitTests.EmployeesTests
{
    public class ServiceTests
    {
        private readonly Mock<IEmployeeService> _employeeServiceMock;

        public ServiceTests()
        {
            _employeeServiceMock = new Mock<IEmployeeService>();

            _employeeServiceMock
                .Setup(s => s.GetAll())
                .Returns(new StandarResponseDto
                {
                    StatusCode = 200,
                    StatusMessage = "Process completed successfully",
                    ProcessDate = "",
                    Data = null
                });

            _employeeServiceMock
                .Setup(s => s.GetById(1))
                .Returns(new StandarResponseDto
                {
                    StatusCode = 200,
                    StatusMessage = "Process completed successfully",
                    ProcessDate = "",
                    Data = null
                });

            _employeeServiceMock
                .Setup(s => s.Create(new EmployeeDto
                {
                    Dni = "1152188707",
                    Name = "Mauricio Alexander",
                    LastName = "Lopera Rivera",
                    Email = "lopera.rivera@gmail.com",
                    Salary = 8000000,
                    JobPositionName = "Developer",
                    Department = "Ingenieria"
                }))
                .Returns(new StandarResponseDto
                {
                    StatusCode = 200,
                    StatusMessage = "Process completed successfully",
                    ProcessDate = "",
                    Data = null
                });

            _employeeServiceMock
                .Setup(s => s.Update(new EmployeeDto
                {
                    Id = 1,
                    Dni = "1152188707",
                    Name = "Mauricio Alexander",
                    LastName = "Lopera Rivera",
                    Email = "lopera.rivera@gmail.com",
                    Salary = 8000000,
                    JobPositionName = "Developer",
                    Department = "Ingenieria"
                }))
                .Returns(new StandarResponseDto
                {
                    StatusCode = 200,
                    StatusMessage = "Process completed successfully",
                    ProcessDate = "",
                    Data = null
                });

            _employeeServiceMock
                .Setup(s => s.Update(new EmployeeDto
                {
                    Id = 1,
                    Dni = "1152188707",
                    Name = "Mauricio Alexander",
                    LastName = "Lopera Rivera",
                    Email = "lopera.rivera@gmail.com",
                    Salary = 8000000,
                    JobPositionName = "Developer",
                    Department = "Ingenieria"
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
        private void Employee_GetAll_OK_Test()
        {

            StandarResponseDto getList = _employeeServiceMock.Object.GetAll();

            Assert.Equal(200, getList.StatusCode);
        }

        [Fact]
        private void Employee_GetAll_NotFound_Test()
        {

            StandarResponseDto getList = _employeeServiceMock.Object.GetAll();

            Assert.NotEqual(403, getList.StatusCode);
        }

        [Fact]
        private void Employee_GetById_OK_Test()
        {

            StandarResponseDto getOne = _employeeServiceMock.Object.GetById(1);

            Assert.Equal(200, getOne.StatusCode);
        }

        [Fact]
        private void Employee_GetById_NotFound_Test()
        {

            StandarResponseDto getOne = _employeeServiceMock.Object.GetById(1);

            Assert.NotEqual(403, getOne.StatusCode);
        }

        [Fact]
        private void Employee_Create_OK_Test()
        {

            StandarResponseDto setOne = _employeeServiceMock.Object.Create(new EmployeeDto());

            Assert.Equal(null, setOne);
        }

        [Fact]
        private void Employee_Create_NotFound_Test()
        {

            StandarResponseDto setOne = _employeeServiceMock.Object.Create(new EmployeeDto());

            Assert.NotEqual(new StandarResponseDto(), setOne);
        }

        [Fact]
        private void Employee_Update_OK_Test()
        {

            StandarResponseDto setOne = _employeeServiceMock.Object.Update(new EmployeeDto());

            Assert.Equal(null, setOne);
        }

        [Fact]
        private void Employee_Update_NotFound_Test()
        {

            StandarResponseDto setOne = _employeeServiceMock.Object.Update(new EmployeeDto());

            Assert.NotEqual(new StandarResponseDto(), setOne);
        }

        [Fact]
        private void Employee_Delete_OK_Test()
        {

            StandarResponseDto setOne = _employeeServiceMock.Object.Delete(new EmployeeDto());

            Assert.Equal(null, setOne);
        }

        [Fact]
        private void Employee_Delete_NotFound_Test()
        {

            StandarResponseDto setOne = _employeeServiceMock.Object.Delete(new EmployeeDto());

            Assert.NotEqual(new StandarResponseDto(), setOne);
        }
    }
}
