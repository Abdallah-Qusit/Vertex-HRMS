namespace VertexHRMS.DAL.Repo.Abstraction
{ 
    public  interface IDepartmentCardsRepo
    {
        bool  Create(Department department);
        bool  Delete(int departmentId);
        Department?  GetById(int departmentId);
        List<Department>  GetDeparts(Expression<Func<Department, bool>>? filter = null);
        Task<List<Department>>  GetAllWithEmployeeAsync();
        Task<Department?>  GetByIdWithEmployeeAsync(int id);
        Task<List<Department>>  SearchDepartmentsAsync(string name);
    }
}
