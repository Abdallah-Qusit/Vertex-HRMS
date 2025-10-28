 ﻿namespace VertexHRMS.BLL.Service.Abstraction
{ 
    public interface  IEmployeeDescriptionService
    { 
        Task<EmployeeDescriptionVM?>  GetByEmployeeId(int employeeId);
    } 
} 
