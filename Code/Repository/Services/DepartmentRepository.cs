
using Models.Departments;
using Models.Dto;
using Repository.DataContext;
using Repository.Interfaces;

namespace Repository.Services
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly PeriferiaTestContext _dbContext;

        public DepartmentRepository(PeriferiaTestContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(Department department)
        {
            _dbContext.Departments.Add(department);
            _dbContext.SaveChanges();
        }

        public void Delete(Department department)
        {
            var reg = _dbContext.Departments.Where(w => w.Id == department.Id).FirstOrDefault();
            _dbContext.Departments.Remove(reg);
            _dbContext.SaveChanges();
        }

        public List<DepartmentDto> GetAll()
        {
            List<DepartmentDto> departments = _dbContext.Departments
                                                                .Select(s => new DepartmentDto
                                                                {
                                                                    Id = s.Id,
                                                                    Name = s.Name
                                                                })
                                                                .OrderBy(o => o.Name).ToList();

            return departments;
        }

        public DepartmentDto GetById(int id)
        {
            DepartmentDto register = _dbContext.Departments
                                                        .Select(s => new DepartmentDto
                                                        {
                                                            Id = s.Id,
                                                            Name = s.Name
                                                        })
                                                        .Where(w => w.Id == id).FirstOrDefault();

            return register;
        }

        public Department GetIdByName(string name)
        {
            Department register = _dbContext.Departments.Where(w => w.Name == name).FirstOrDefault();

            return register;
        }

        public void Update(Department department)
        {
            var reg = _dbContext.Departments.Where(w => w.Id == department.Id).FirstOrDefault();
            reg.Name = department.Name;
            _dbContext.SaveChanges();
        }
    }
}
