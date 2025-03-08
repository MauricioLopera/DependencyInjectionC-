
using Models.Constants;
using Models.Departments;
using Models.Dto;
using Repository.Interfaces;
using System.Net;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Business.Departments
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
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
                List<Department> data = _departmentRepository.GetAll();

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
                Department result = _departmentRepository.GetById(id);

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

        public StandarResponseDto Update(Department department)
        {
            try
            {
                if (_departmentRepository.GetById(department.Id) == null)
                {
                    return new StandarResponseDto
                    {
                        StatusCode = Convert.ToInt32(HttpStatusCode.NotFound),
                        StatusMessage = Messages.NotFound,
                        ProcessDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                        Data = new { Result = "No datum to update"}
                    };
                }

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
