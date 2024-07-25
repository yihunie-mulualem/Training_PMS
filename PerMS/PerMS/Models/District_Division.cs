using PerMS.Models;

namespace PerMS
{
    public class District_Division
    {
      public int Id { get; set; }
      public int Division_Code { get; set; }
      public string Division_Name { get; set; }
      public string Division_CreatedBy { get; set; }
      public DateTime Division_DateCreated { get; set; }
      public bool Division_Active { get; set; }

    }
}
