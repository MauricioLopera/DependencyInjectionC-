
using Models.Enums;

namespace Models.Dto
{
    public class EmployeeDto
    {
        public int? Id { get; set; } = 0;

        public string? Dni { get; set; } = string.Empty;

        public string? Name { get; set; } = string.Empty;

        public string? LastName { get; set; } = string.Empty;

        public string? Email { get; set; } = string.Empty;

        public string? JobPositionName {  get; set; } = string.Empty;

        public decimal? Salary { get; set; } = 0;

        public decimal? Bono { get { return JobPositionName == Enum.GetName(typeof(JobPosition), 1) ? Convert.ToDecimal(Salary) * Convert.ToDecimal(0.1) : JobPositionName == Enum.GetName(typeof(JobPosition), 2) ? Convert.ToDecimal(Salary) * Convert.ToDecimal(0.2) : 0; } }

        public decimal? Total { get { return Salary + Bono; } }

        public string? Department { get; set; }
    }
}
