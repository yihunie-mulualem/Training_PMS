using PerMS.Models;

namespace PerMS
{
    public class HierarchyGroup
    { 
     
      public int Id { get; set; }
     public string HierarchyGroup_Name { get; set; }
     public string HierarchyGroup_Level { get; set; }
     public int HierarchyGroup_ReportsTo { get; set; }
     public string HierarchyGroup_PositionIdentifier { get; set; }
     public string HierarchyGroup_Code { get; set; }
     public ICollection<Employee> Employees { get; set; }



    }
}
