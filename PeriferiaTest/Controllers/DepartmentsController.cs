using Business.Departments;
using Microsoft.AspNetCore.Mvc;
using Models.Constants;
using Models.Departments;
using Models.Dto;
using System.Net;
using System.Text.RegularExpressions;

namespace API.Controllers
{
    [Route("api/departments")]
    [ApiController]
    public class DepartmentsController : Controller
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentsController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody] DepartmentDto data)
        {
            StandarResponseDto response;

            if (data.Name == string.Empty || data.Id > 0)
            {
                response = new StandarResponseDto
                {
                    StatusCode = Convert.ToInt32(HttpStatusCode.BadRequest),
                    StatusMessage = Messages.Warning,
                    ProcessDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    Data = new { Required = "Name", NotAllowed = "Id" }
                };
            }
            else
            {
                Department department = new Department
                {
                    Name = data.Name
                };

                response = _departmentService.Create(department);
            }

            return StatusCode(response.StatusCode, response);
        }

        [HttpGet]
        [Route("get/{id}")]
        public IActionResult GetById(string id)
        {
            StandarResponseDto response;
            Regex regex = new Regex(@"^\d+$");

            if (!regex.IsMatch(id))
            {
                response = new StandarResponseDto
                {
                    StatusCode = Convert.ToInt32(HttpStatusCode.BadRequest),
                    StatusMessage = Messages.Warning,
                    ProcessDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    Data = new { Id = "Numeric Only" }
                };

                return StatusCode(response.StatusCode, response);
            }

            response = _departmentService.GetById(int.Parse(id));

            return StatusCode(response.StatusCode, response);
        }

        [HttpGet]
        [Route("getAll")]
        public IActionResult GetAll()
        {
            StandarResponseDto response = _departmentService.GetAll();

            return StatusCode(response.StatusCode, response);
        }

        [HttpPut]
        [Route("update")]
        public IActionResult Update([FromBody] DepartmentDto data)
        {
            StandarResponseDto response;

            if (data.Name == string.Empty || data.Id == 0)
            {
                response = new StandarResponseDto
                {
                    StatusCode = Convert.ToInt32(HttpStatusCode.BadRequest),
                    StatusMessage = Messages.Warning,
                    ProcessDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    Data = new { Required = "Id, Name" }
                };
            }
            else
            {
                Department department = new Department
                {
                    Id = Convert.ToInt32(data.Id),
                    Name = data.Name
                };

                response = _departmentService.Update(department);
            }

            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete]
        [Route("delete")]
        public IActionResult Delete([FromBody] DepartmentDto data)
        {
            StandarResponseDto response;

            if (data.Name == string.Empty || data.Id == 0)
            {
                response = new StandarResponseDto
                {
                    StatusCode = Convert.ToInt32(HttpStatusCode.BadRequest),
                    StatusMessage = Messages.Warning,
                    ProcessDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    Data = new { Required = "Id, Name" }
                };
            }
            else
            {
                Department department = new Department
                {
                    Id = Convert.ToInt32(data.Id),
                    Name = data.Name
                };

                response = _departmentService.Delete(department);
            }

            return StatusCode(response.StatusCode, response);
        }
    }
}
