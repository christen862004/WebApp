
namespace WebApp.Repository
{
    public class DepartmentRepository : IDepartmentRepository //IRepository<Department>
    {
        //CRUD cREATE -REad- update -delete
        ITIContext context;
        public DepartmentRepository(ITIContext _ctx)
        {
            context = _ctx;
        }

        public void Add(Department entity)
        {
           context.Department.Add(entity);
        }

        public void Delete(int id)
        {
            Department dep=GetById(id);
            context.Department.Remove(dep);
        }

        public List<Department> GetAll()
        {
            return context.Department.ToList(); 
        }

        public Department GetById(int id)
        {
            return context.Department.FirstOrDefault(d => d.Id == id);
        }

        public void Save()
        {
            context.SaveChanges();
        }
        public void Update(Department entity)
        {
                Department depFromDB = GetById(entity.Id);
                depFromDB.Name= entity.Name;
                depFromDB.ManagerName= entity.ManagerName;

        }
    }
}
