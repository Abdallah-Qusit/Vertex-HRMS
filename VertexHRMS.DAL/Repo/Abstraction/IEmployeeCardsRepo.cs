
namespace VertexHRMS.DAL.Repo.Abstraction
{ 
     public interface IEmployeeCardsRepo
     {
        (List<Employee>,string?) GetByDepartmentId(int departmentId); 
     } 
} 
