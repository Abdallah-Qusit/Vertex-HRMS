
namespace VertexHRMS.DAL.Repo.Implementation
{ 
    public  class DepartmentCardsRepo : IDepartmentCardsRepo
    {
        private  readonly VertexHRMSDbContext _db;
        public  DepartmentCardsRepo(VertexHRMSDbContext db)
        {
            _db =  db;
        }

        public  bool Create(Department department)
        {
            try 
            {
                 _db.Departments.Add(department);
                 _db.SaveChanges();
                 return department.DepartmentId > 0;
            }
            catch
            {
                 return false;
            }
        }

        public  bool Delete(int departmentId)
        {
            try
            { 
                var department =  _db.Departments.FirstOrDefault(d => d.DepartmentId == departmentId);
                if  (department != null)
                {
                     _db.Departments.Remove(department);
                     _db.SaveChanges();
                     return true;
                } 
                return false;
            }
            catch
            {
                 return false;
            }
        }

        public  Department? GetById(int departmentId)
        {
            try
            {
                return _db.Departments.FirstOrDefault(d => d.DepartmentId == departmentId);
            }
            catch
            {
                 return null;
            }
        }

        public List<Department>  GetDeparts(Expression<Func<Department, bool>>? filter = null)
        {
            try
            {
                if  (filter != null)
                {
                     return _db.Departments
                               .Include(d => d.Employees)
                               .Where(filter)
                               .ToList();
                }
                return _db.Departments
                          .Include(d => d.Employees)
                          .ToList();
            }
            catch
            {
                return new List<Department>();
            }
        }

        public async Task<List<Department>> GetAllWithEmployeeAsync()
        {
             return await _db.Departments
                             .Include(d => d.Employees)
                             .ToListAsync();
        }

        public async Task<Department?> GetByIdWithEmployeeAsync(int id)
        {
             if (id <= 0) return null;
             return await _db.Departments
                             .Include(d => d.Employees)
                             .FirstOrDefaultAsync(d => d.DepartmentId == id);
        }
        
       public async Task<List<Department>> SearchDepartmentsAsync(string name)
        {
             return await _db.Departments
                 .Where(d => d.DepartmentName.Contains(name))
                 .ToListAsync();
        }
    }
    }
