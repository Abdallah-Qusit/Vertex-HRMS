
namespace VertexHRMS.DAL.Repo.Implementation
{
     public class EmployeeCardsRepo : IEmployeeCardsRepo
    {
         private readonly VertexHRMSDbContext Db;
         public EmployeeCardsRepo(VertexHRMSDbContext db)
         {
            Db = db;
         }

         public (List<Employee>, string?) GetByDepartmentId(int departmentId)
        { 
          try
            {
                var result =  Db.Employees.Include(e => e.Position).Where(e => e.DepartmentId == departmentId).ToList();
                if (!result.Any())
                {
                     return (null, "No employees found in this department");
                }
                return (result, null);
            }
            catch (Exception ex)
            {
                 
                 return (null,ex.Message);
            }
        }

    }
}
