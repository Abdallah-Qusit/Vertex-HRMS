 ﻿namespace VertexHRMS.BLL.ModelVM.Department
{ 
     public class GetDepartmentCardsVM
     {
         public int DepartmentId { get; set; }
         public string DepartmentName { get; set; }
         public string Description { get; set; }  
         public List<GetAllUserByDepartmentIdVM> Employees { get; set; } = new();
     } 
} 
