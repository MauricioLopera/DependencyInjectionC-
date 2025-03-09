
using Models.Constants;
using Models.Departments;
using Models.Dto;
using Repository.Interfaces;
using System.Net;

namespace Business.Departments
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public DepartmentService(IDepartmentRepository departmentRepository, IEmployeeRepository employeeRepository)
        {
            _departmentRepository = departmentRepository;
            _employeeRepository = employeeRepository;
        }

        public StandarResponseDto Create(Department department)
        {
            try
            {
                _departmentRepository.Create(department);

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
                    Data = new {Message = ex.Message}
                };
            }
        }

        public StandarResponseDto Delete(Department department)
        {
            try
            {
                #region Validations
                if (_employeeRepository.GetByDepartment(department.Id).Count > 0)
                {
                    return new StandarResponseDto
                    {
                        StatusCode = Convert.ToInt32(HttpStatusCode.Forbidden),
                        StatusMessage = Messages.Exist,
                        ProcessDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                        Data = new { Result = "There are some employees asociated to this department" }
                    };
                }
                #endregion

                _departmentRepository.Delete(department);

                return new StandarResponseDto
                {
                    StatusCode = Convert.ToInt32(HttpStatusCode.OK),
                    StatusMessage = Messages.Success,
                    ProcessDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    Data = new { Deleted = "True" }
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
                List<DepartmentDto> data = _departmentRepository.GetAll();

                if(data.Count == 0)
                {
                    return new StandarResponseDto
                    {
                        StatusCode = Convert.ToInt32(HttpStatusCode.NotFound),
                        StatusMessage = Messages.NotFound,
                        ProcessDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                        Data = new {}
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
                DepartmentDto result = _departmentRepository.GetById(id);

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

        public StandarResponseDto GetEmployeesByDepartmentId(int id)
        {
            try
            {
                List<EmployeeDto> result = _employeeRepository.GetByDepartment(id);

                if (result.Count == 0)
                {
                    return new StandarResponseDto
                    {
                        StatusCode = Convert.ToInt32(HttpStatusCode.NotFound),
                        StatusMessage = Messages.NotFound,
                        ProcessDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                        Data = new { Result = "There are no employees for its department" }
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

        public StandarResponseDto Update(Department department)
        {
            try
            {
                #region Validations
                if (_departmentRepository.GetById(department.Id) == null)
                {
                    return new StandarResponseDto
                    {
                        StatusCode = Convert.ToInt32(HttpStatusCode.NotFound),
                        StatusMessage = Messages.NotFound,
                        ProcessDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                        Data = new { Result = "No datum to update" }
                    };
                }
                #endregion

                _departmentRepository.Update(department);

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
