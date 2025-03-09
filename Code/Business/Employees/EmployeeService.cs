
using Models.Constants;
using Models.Departments;
using Models.Dto;
using Models.Employees;
using Models.Enums;
using Repository.Interfaces;
using System.Net;

namespace Business.Employees
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IDepartmentRepository _departmentRepository;

        public EmployeeService(IEmployeeRepository employeeRepository, IDepartmentRepository departmentRepository)
        {
            _employeeRepository = employeeRepository;
            _departmentRepository = departmentRepository;
        }

        public StandarResponseDto Create(EmployeeDto employee)
        {
            try
            {
                #region Validations
                int jobPositionId = (int)(JobPosition)Enum.Parse(typeof(JobPosition), employee.JobPositionName, true);

                if (jobPositionId == 0)
                {
                    return new StandarResponseDto
                    {
                        StatusCode = Convert.ToInt32(HttpStatusCode.BadRequest),
                        StatusMessage = Messages.Invalid,
                        ProcessDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                        Data = new { JobPosition = "Invalid value" }
                    };
                }

                Department department = _departmentRepository.GetIdByName(employee.Department);

                if (department == null)
                {
                    return new StandarResponseDto
                    {
                        StatusCode = Convert.ToInt32(HttpStatusCode.NotFound),
                        StatusMessage = Messages.NotFound,
                        ProcessDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                        Data = new { Result = "Invalid DepartmentId" }
                    };
                }

                if (_employeeRepository.GetByDni(employee.Dni) != null)
                {
                    return new StandarResponseDto
                    {
                        StatusCode = Convert.ToInt32(HttpStatusCode.Forbidden),
                        StatusMessage = Messages.Exist,
                        ProcessDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                        Data = new { Result = "Employee already exists" }
                    };
                }
                #endregion

                Employee reg = new Employee
                {
                    Dni = employee.Dni,
                    Name = employee.Name,
                    LastName = employee.LastName,
                    Email = employee.Email,
                    Salary = Convert.ToDecimal(employee.Salary),
                    DepartmentId = department.Id,
                    JobPositionId = jobPositionId
                };

                _employeeRepository.Create(reg);

                return new StandarResponseDto
                {
                    StatusCode = Convert.ToInt32(HttpStatusCode.OK),
                    StatusMessage = Messages.Success,
                    ProcessDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    Data = new { Created = "True" }
                };
            }
            catch (Exception ex)
            {
                return new StandarResponseDto()
                {
                    StatusCode = Convert.ToInt32(HttpStatusCode.InternalServerError),
                    StatusMessage = Messages.Error,
                    ProcessDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    Data = new { Message = ex.Message }
                };
            }
        }

        public StandarResponseDto Delete(EmployeeDto employee)
        {
            try
            {
                Employee reg = new Employee
                {
                    Id = Convert.ToInt32(employee.Id)
                };

                _employeeRepository.Delete(reg);

                return new StandarResponseDto
                {
                    StatusCode = Convert.ToInt32(HttpStatusCode.OK),
                    StatusMessage = Messages.Success,
                    ProcessDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    Data = new { Created = "True" }
                };
            }
            catch (Exception ex)
            {
                return new StandarResponseDto()
                {
                    StatusCode = Convert.ToInt32(HttpStatusCode.InternalServerError),
                    StatusMessage = Messages.Error,
                    ProcessDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    Data = new { Message = ex.Message }
                };
            }
        }

        public StandarResponseDto GetAll()
        {
            try
            {
                List<EmployeeDto> data = _employeeRepository.GetAll();

                if (data.Count == 0)
                {
                    return new StandarResponseDto
                    {
                        StatusCode = Convert.ToInt32(HttpStatusCode.NotFound),
                        StatusMessage = Messages.NotFound,
                        ProcessDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                        Data = new { }
                    };
                }

                return new StandarResponseDto
                {
                    StatusCode = Convert.ToInt32(HttpStatusCode.OK),
                    StatusMessage = Messages.Success,
                    ProcessDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    Data = data
                };
            }
            catch (Exception ex)
            {
                return new StandarResponseDto()
                {
                    StatusCode = Convert.ToInt32(HttpStatusCode.InternalServerError),
                    StatusMessage = Messages.Error,
                    ProcessDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    Data = new { Message = ex.Message }
                };
            }
        }

        public StandarResponseDto GetById(int id)
        {
            try
            {
                EmployeeDto result = _employeeRepository.GetById(id);

                if (result == null)
                {
                    return new StandarResponseDto
                    {
                        StatusCode = Convert.ToInt32(HttpStatusCode.NotFound),
                        StatusMessage = Messages.NotFound,
                        ProcessDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                        Data = new { }
                    };
                }

                return new StandarResponseDto
                {
                    StatusCode = Convert.ToInt32(HttpStatusCode.OK),
                    StatusMessage = Messages.Success,
                    ProcessDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    Data = result
                };
            }
            catch (Exception ex)
            {
                return new StandarResponseDto()
                {
                    StatusCode = Convert.ToInt32(HttpStatusCode.InternalServerError),
                    StatusMessage = Messages.Error,
                    ProcessDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    Data = new { Message = ex.Message }
                };
            }
        }

        public StandarResponseDto Update(EmployeeDto employee)
        {
            try
            {
                #region Validations
                int jobPositionId = (int)(JobPosition)Enum.Parse(typeof(JobPosition), employee.JobPositionName, true);

                if (jobPositionId == 0)
                {
                    return new StandarResponseDto
                    {
                        StatusCode = Convert.ToInt32(HttpStatusCode.BadRequest),
                        StatusMessage = Messages.Invalid,
                        ProcessDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                        Data = new { JobPosition = "Invalid value" }
                    };
                }

                Department department = _departmentRepository.GetIdByName(employee.Department);

                if (department == null)
                {
                    return new StandarResponseDto
                    {
                        StatusCode = Convert.ToInt32(HttpStatusCode.NotFound),
                        StatusMessage = Messages.NotFound,
                        ProcessDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                        Data = new { Result = "Invalid DepartmentId" }
                    };
                }
                #endregion

                Employee reg = new Employee
                {
                    Id = Convert.ToInt32(employee.Id),
                    Dni = employee.Dni,
                    Name = employee.Name,
                    LastName = employee.LastName,
                    Email = employee.Email,
                    Salary = Convert.ToDecimal(employee.Salary),
                    DepartmentId = department.Id,
                    JobPositionId = jobPositionId
                };

                _employeeRepository.Update(reg);

                return new StandarResponseDto
                {
                    StatusCode = Convert.ToInt32(HttpStatusCode.OK),
                    StatusMessage = Messages.Success,
                    ProcessDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    Data = new { Updated = "True" }
                };
            }
            catch (Exception ex)
            {
                return new StandarResponseDto()
                {
                    StatusCode = Convert.ToInt32(HttpStatusCode.InternalServerError),
                    StatusMessage = Messages.Error,
                    ProcessDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    Data = new { Message = ex.Message }
                };
            }
        }
    }
}
