
namespace VertexHRMS.BLL.Service.Implementation
{ 
    public class  EmployeeCardsService : IEmployeeCardsService
    {
        private readonly  IEmployeeCardsRepo _employeeCardsRepo;

        public  EmployeeCardsService(IEmployeeCardsRepo employeeCardsRepo) {
            _employeeCardsRepo =  employeeCardsRepo;
        }
        public async Task<EmployeeCardsVM>  GetByDepartmentId(int departmentId)
        { 
            try 
            { 
                var result =  _employeeCardsRepo.GetByDepartmentId(departmentId);
                if (result.Item2 != null) 
                { 
                    return new EmployeeCardsVM
                    { 
                        HasError = true,
                        Message = result.Item2
                    }; 


				}
                
				if (result.Item1 == null || !result.Item1.Any())
				{ 
					return new  EmployeeCardsVM
					{
						HasError =  true,
						Message =  "There are no employees in this department"
					};
				} 
				List<GetAllUserByDepartmentIdVM>  getAllUserByDepartmentIds = new List<GetAllUserByDepartmentIdVM>();
                foreach(var item in result.Item1) 
                {
					getAllUserByDepartmentIds.Add(new() { FirstName = item.FirstName, LastName = item.LastName, ImagePath = item.ImagePath, DepartmentId = item.DepartmentId, EmployeeId=item.EmployeeId });
                }
				return new  EmployeeCardsVM
				{ 
					Employees =  getAllUserByDepartmentIds,
					HasError = false,
					Message = null
				}; 
			} 
			catch  (Exception ex)
			{
				return new  EmployeeCardsVM
				{ 
					HasError =  true,
					Message =  ex.Message
				}; 
			} 
		} 
    } 
} 
