using PerMS.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace PerMS
{
    public class Department
    {
        public int Id { get; set; }
        public int Department_Code { get; set; }
        public string Department_Name { get; set; }
        public string Department_CreatedBy { get; set; }
        public DateTime Department_DateCreated { get; set; }
        public bool Department_Active { get; set; }
        public int BussinesUnitId { get; set; }
        public BussinesUnit BussinesUnit { get; set; }
        public ICollection<Employee> Employees { get; set; }

    }
}

