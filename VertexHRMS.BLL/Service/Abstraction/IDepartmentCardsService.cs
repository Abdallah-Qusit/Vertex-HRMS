namespace  VertexHRMS.BLL.Service.Abstraction
{
    public  interface IDepartmentCardsService
    { 
        (bool, string)  Create(CreateDepartmentCardsVM depart);
        (bool, string,  List<GetDepartmentCardsVM>) Getdepart();
        Task<List<GetDepartmentCardsVM>>  GetAllDepartmentsAsync();
        Task<GetDepartmentCardsVM>  GetDepartmentByIdAsync(int id);
        Task<List<GetDepartmentCardsVM>>  SearchDepartmentsAsync(string name);
    } 
} 
