
using Models.Departments;
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

        public List<Department> GetAll()
        {
            List<Department> departments = _dbContext.Departments.OrderBy(o => o.Id).ToList();

            return departments;
        }

        public Department GetById(int id)
        {
            Department register = _dbContext.Departments.Where(w => w.Id == id).FirstOrDefault();

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
