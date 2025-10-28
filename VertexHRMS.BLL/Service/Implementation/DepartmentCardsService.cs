namespace  VertexHRMS.BLL.Service.Implementation
{ 
    public class  DepartmentCardsService : IDepartmentCardsService
    {
        private readonly  IDepartmentCardsRepo departRepo;
        private readonly  IMapper mapper;

        public  DepartmentCardsService(IMapper mapper, IDepartmentCardsRepo departRepo)
        {
            this.departRepo =  departRepo;
            this.mapper =  mapper;
        }


        public (bool, string, List<GetDepartmentCardsVM>)  Getdepart()
        {
            try
            { 
                var departs  = departRepo.GetDeparts();
                var result  = mapper.Map<List<GetDepartmentCardsVM>>(departs);
                return  (false, null, result);
            }
            catch  (Exception ex)
            { 
                return  (true, ex.Message, null);
            } 
        } 

 
        public async  Task<List<GetDepartmentCardsVM>> GetAllDepartmentsAsync()
        {
            var list  = await departRepo.GetAllWithEmployeeAsync();
            return  list.Select(d => new GetDepartmentCardsVM
            { 
                DepartmentId =  d.DepartmentId,
                DepartmentName =  d.DepartmentName,
                Employees =  d.Employees.Select(u => new GetAllUserByDepartmentIdVM
                {
                    EmployeeId =  u.EmployeeId,
                    FirstName =  u.FirstName,
                    LastName =  u.LastName,
                    DepartmentId =  u.DepartmentId
                }).ToList() 
            }).ToList(); 
        } 


        public async  Task<GetDepartmentCardsVM> GetDepartmentByIdAsync(int id)
        {
            var d =  await departRepo.GetByIdWithEmployeeAsync(id);
            if (d == null) return  null;

            return new GetDepartmentCardsVM 
            {
                DepartmentId =  d.DepartmentId,
                DepartmentName =  d.DepartmentName,
                Employees =  d.Employees.Select(u => new GetAllUserByDepartmentIdVM
                { 
                    EmployeeId =  u.EmployeeId,
                    FirstName =  u.FirstName,
                    LastName =  u.LastName,
                    DepartmentId =  u.DepartmentId
                }).ToList() 
            }; 
        } 

 
        public (bool, string)  Create(CreateDepartmentCardsVM depart)
        { 
            try
            {
                var newDepartment  = new Department(depart.DepartmentName);


                var result =  departRepo.Create(newDepartment);
                if (result) 
                    return (false, null); 
 
                return (true, "There was an error saving the department.");
            }
            catch  (Exception ex)
            {
                return  (true, ex.Message);
            } 
        } 
        public async  Task<List<GetDepartmentCardsVM>> SearchDepartmentsAsync(string name)
        {
            List<Department> entities; 
 
            if  (string.IsNullOrWhiteSpace(name))
                entities =  await departRepo.GetAllWithEmployeeAsync(); 
            else
                entities =  await departRepo.SearchDepartmentsAsync(name); 

            var vms =  entities.Select(d => new GetDepartmentCardsVM
            {
                DepartmentId =  d.DepartmentId,
                DepartmentName =  d.DepartmentName,
                Employees =  d.Employees?.Select(e => new GetAllUserByDepartmentIdVM
                {
                    EmployeeId =  e.EmployeeId,
                    FirstName =  e.FirstName,
                    LastName =  e.LastName,
                    DepartmentId =  e.DepartmentId
                }).ToList() ?? new List<GetAllUserByDepartmentIdVM>()
            }).ToList();
 
            return vms; 
        }
    }
}
