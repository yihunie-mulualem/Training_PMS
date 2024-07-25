using PerMS.Models;

namespace PerMS
{
    public class JobPosition
    { 
     
      public int Id { get; set; }
      public string JobPosition_Code { get; set; }
      public string JobPosition_Title { get; set; }
      public int JobPosition_Grade { get; set; }
      public int JobPosition_Category { get; set;}
      public string JobPosition_CreatedBy { get; set; }
      public string JobPosition_DateCreated { get; set; }
     public string JobPosition_Active { get; set; }
     public ICollection<Employee> Employees { get; set; }


    }
}
