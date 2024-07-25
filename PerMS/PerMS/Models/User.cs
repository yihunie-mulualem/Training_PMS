using System;
using System.ComponentModel.DataAnnotations.Schema;
using PerMS.Models;

namespace PerMS
{
    public class User
    {
        public int Id { get; set; }
        public string User_UserName { get; set; }
        public string User_Password { get; set; }
        public string User_FullName { get; set; }
        public int User_EmployeeId { get; set; }
        [ForeignKey("User_EmployeeId")]
        public virtual Employee Employee { get; set; }
        public int User_BussinesUnitId { get; set; }
        [ForeignKey("User_BussinesUnitId")]
        public virtual BussinesUnit BussinesUnit { get; set; }
        public int User_RoleId { get; set; }
        [ForeignKey("User_RoleId")]
        public virtual Role Role { get; set; }
        public string User_CreateBy { get; set; }
        public DateTime User_CreateDate { get; set; }
        public bool User_Active { get; set; }
        public string User_Remark { get; set; }

    }
}
