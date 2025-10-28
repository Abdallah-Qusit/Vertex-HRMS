using  System;
using  System.Collections.Generic;
namespace  VertexHRMS.BLL.Service.Abstraction
{
    public interface  IEmployeeCardsService
    { 
        Task<EmployeeCardsVM?>  GetByDepartmentId(int departmentId);
    } 
} 
