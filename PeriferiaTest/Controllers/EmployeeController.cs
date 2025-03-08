using Business.Employees;
using Microsoft.AspNetCore.Mvc;
using Models.Constants;
using Models.Departments;
using Models.Dto;
using System.Net;
using System.Text.RegularExpressions;

namespace API.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody] EmployeeDto data)
        {
            StandarResponseDto response = null;
            Regex regex = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");

            if (data.Name == string.Empty || data.Id > 0 || data.LastName == string.Empty || data.Email == string.Empty || data.Dni == string.Empty || data.JobPositionName == string.Empty || data.Department == string.Empty || data.Salary == null)
            {
                response = new StandarResponseDto
                {
                    StatusCode = Convert.ToInt32(HttpStatusCode.BadRequest),
                    StatusMessage = Messages.Warning,
                    ProcessDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    Data = new { Required = "Name, LastName, Email, Dni, JobPosition, DepartmentId, Salary", NotAllowed = "Id" }
                };
            }

            if (!regex.IsMatch(data.Email))
            {
                response = new StandarResponseDto
                {
                    StatusCode = Convert.ToInt32(HttpStatusCode.BadRequest),
                    StatusMessage = Messages.Warning,
                    ProcessDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    Data = new { Email = "Email format" }
                };
            }

            if(response == null)
                response = _employeeService.Create(data);

            return StatusCode(response.StatusCode, response);
        }

        [HttpGet]
        [Route("getAll")]
        public IActionResult GetAll()
        {
            StandarResponseDto response = _employeeService.GetAll();

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

            response = _employeeService.GetById(int.Parse(id));

            return StatusCode(response.StatusCode, response);
        }

        [HttpPut]
        [Route("update")]
        public IActionResult Update([FromBody] EmployeeDto data)
        {
            StandarResponseDto response = null;
            Regex regex = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");

            if (data.Name == string.Empty || data.Id == 0 || data.LastName == string.Empty || data.Email == string.Empty || data.Dni == string.Empty || data.JobPositionName == string.Empty || data.Department == string.Empty || data.Salary == null)
            {
                response = new StandarResponseDto
                {
                    StatusCode = Convert.ToInt32(HttpStatusCode.BadRequest),
                    StatusMessage = Messages.Warning,
                    ProcessDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    Data = new { Required = "Name, LastName, Email, Dni, JobPosition, DepartmentId, Salary, Id" }
                };
            }

            if (!regex.IsMatch(data.Email))
            {
                response = new StandarResponseDto
                {
                    StatusCode = Convert.ToInt32(HttpStatusCode.BadRequest),
                    StatusMessage = Messages.Warning,
                    ProcessDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    Data = new { Email = "Email format" }
                };
            }

            if (response == null)
                response = _employeeService.Update(data);

            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete]
        [Route("delete")]
        public IActionResult Delete([FromBody] EmployeeDto data)
        {
            StandarResponseDto response;

            if (data.Id == 0)
            {
                response = new StandarResponseDto
                {
                    StatusCode = Convert.ToInt32(HttpStatusCode.BadRequest),
                    StatusMessage = Messages.Warning,
                    ProcessDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    Data = new { Required = "Id" }
                };
            }
            else
            {

                response = _employeeService.Delete(data);
            }

            return StatusCode(response.StatusCode, response);
        }
    }
}
