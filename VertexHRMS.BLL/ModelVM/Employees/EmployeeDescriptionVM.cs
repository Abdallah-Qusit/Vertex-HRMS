namespace VertexHRMS.BLL.ModelVM.Employees
{ 
     public class EmployeeDescriptionVM
     {
         public int DepartmentId { get; set; }
         public int EmployeeId { get; set; }
         public string EmployeeCode { get;  set; }
         public string FirstName { get;  set; }
         public string LastName { get;  set; }
         public string Email { get;  set; }
         public string Phone { get;  set; }
         public string EmploymentType { get;  set; }
         public string Status { get;  set; }
         public string DepartmentName { get;  set; }
         public decimal BaseSalary { get;  set; }
         public decimal GrossEarnings { get;  set; }
         public decimal NetSalary { get;  set; }
         public string PositionName { get;  set; }
         public string ImagePath { get; set; }
     } 
} 
