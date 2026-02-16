using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace WebApp.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        ITIContext context;
        public EmployeeRepository(ITIContext _ctx)
        {
            context = _ctx;
        }
        public void Add(Employee entity)
        {
            context.Employees.Add(entity);
        }

        public void Delete(int id)
        {
            context.Employees.Remove(GetById(id));
        }

        public List<Employee> GetAll()
        {
            return context.Employees.ToList();
        }

        public Employee GetById(int id)
        {
            return context.Employees.FirstOrDefault(e => e.Id == id);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Employee entity)
        {
            Employee empFRomDb = GetById(entity.Id);
            empFRomDb.Name=entity.Name;
            empFRomDb.Salary=entity.Salary;
            empFRomDb.ImageURL=entity.ImageURL;
            empFRomDb.Email=entity.Email;
            empFRomDb.DepartmentID=entity.DepartmentID;
        }
    }
}
