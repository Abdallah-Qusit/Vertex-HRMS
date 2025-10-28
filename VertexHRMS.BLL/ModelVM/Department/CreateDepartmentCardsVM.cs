
namespace VertexHRMS.BLL.ModelVM.Department
{ 
    public class  CreateDepartmentCardsVM
    { 
         [Required(ErrorMessage = "Name is required :(")]
         [MinLength(2, ErrorMessage = "Plz Enter Length bigger Than 2 :(")]
         public string DepartmentName { get; set; }   
 
         public string Description { get; set; }      
    } 
} 
