
namespace VertexHRMS.BLL.Service.Implementation
{ 
    public class  EmployeeDescriptionService : IEmployeeDescriptionService
    {
        private readonly  IEmployeeDescriptionRepo _employeeDescriptionRepo;
        public  EmployeeDescriptionService(IEmployeeDescriptionRepo employeeDescriptionRepo)
        {
            _employeeDescriptionRepo =  employeeDescriptionRepo;
        } 
        public async  Task<EmployeeDescriptionVM?> GetByEmployeeId(int EmployeeId)
        { 
            var result =  _employeeDescriptionRepo.GetByEmployeeId(EmployeeId);
            if (result == null)
            { 
                 return null; 
            } 


            var employeeDescriptionVM = new EmployeeDescriptionVM
            {
                EmployeeId =  result.EmployeeId,
                EmployeeCode =  result.EmployeeCode,
                FirstName =  result.FirstName,
                LastName =  result.LastName,
                Email =  result.Email,
                Phone =  result.Phone,
                EmploymentType =  result.EmploymentType,
                Status =  result.Status,
                DepartmentName =  result.Department.DepartmentName, 
                PositionName =  result.Position.PositionName,     
                BaseSalary =  result.Position.BaseSalary,
                ImagePath =  result.ImagePath ,
                DepartmentId =  result.Department.DepartmentId
            }; 

            return employeeDescriptionVM;
        }
    }
}
