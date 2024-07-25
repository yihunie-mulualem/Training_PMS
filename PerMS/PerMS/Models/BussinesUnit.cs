using PerMS.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PerMS
{
    public class BussinesUnit
    {
        [Key]
       public int Id { get; set; }
       public string BussinesUnit_Code { get; set; }
       public string BussinesUnit_Name { get; set; }
       public int ClusterId{ get; set; }
       public virtual Cluster Clusters { get; set; }
       public virtual ICollection<User> Users { get; set; }
       public virtual ICollection<Employee> Employees { get; set; }
       public virtual Department Departments { get; set; }



    }
}
