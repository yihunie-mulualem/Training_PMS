using PerMS.Models;

namespace PerMS
{
    public class Role
    { 
      public int Id { get; set; }
      public string Role_Name { get; set; }
      public string Role_CreateBy { get; set; }
      public DateTime Role_CreateDate { get; set; }
      public string Role_LastModfBy { get; set; }
      public DateTime Role_LastModfDate { get; set; }
      public bool Role_Active { get; set; }
      public ICollection<User> Users { get; set; }


    }
}
