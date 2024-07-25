using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PerMS.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        public int MainID { get; set; }
        public string Employee_FullName { get; set; }
        public string Employee_Gender { get; set; }
        public string Employee_EmploymentType { get; set; }
        public string Employee_EmployeeStatus { get; set; }
    

        public int Employee_GradeLevel { get; set; }
        public string Employee_Remark { get; set; }
        public string Employee_CreatedBy { get; set; }
        public DateTime Employee_DateCreated { get; set; }
        public bool Employee_Active { get; set; }
        public DateTime Employee_ContractExpiryDate { get; set; }
        public int JobPositionId { get; set; }
        public virtual JobPosition JobPosition { get; set; }
        public int BussinesUnitId { get; set; }
        public virtual BussinesUnit BussinesUnit { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        [ForeignKey("HierarchyGroup")]
        public int HierarchyGroupId { get; set; }
        public virtual HierarchyGroup HierarchyGroup { get; set; }
    }
}
