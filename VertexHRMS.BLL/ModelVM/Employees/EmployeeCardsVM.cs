namespace VertexHRMS.BLL.ModelVM.Employees
{ 
	 public class EmployeeCardsVM
	 {
		 public List<GetAllUserByDepartmentIdVM> Employees { get; set; } = new();
		 public string? Message { get; set; }
		 public bool HasError { get; set; }
	 } 
} 
