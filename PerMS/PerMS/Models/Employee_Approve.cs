using System;
using System.ComponentModel.DataAnnotations.Schema;
using PerMS.Models;

namespace PerMS
{
    public class Employee_Approve
    {
        public int Id { get; set; }
        public int EmployeeID { get; set; }
        [ForeignKey("EmployeeID")]
        public int HeadMonthlyPMS_ID{ get; set; }
        [ForeignKey("HeadMonthlyPMS_ID")]
        public virtual HeadQuarterlyPms HeadQuarterlyPms { get; set; }

    }
}
