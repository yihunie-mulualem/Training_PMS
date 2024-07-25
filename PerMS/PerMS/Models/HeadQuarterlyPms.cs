using PerMS.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace PerMS
{
    public class HeadQuarterlyPms
    {
        public int Id { get; set; }
        public int Employee_Id { get; set; }
        [ForeignKey("Employee_Id")]
        public Employee Employees { get; set; }

        public int FiscalYear_Id { get; set; }
        [ForeignKey("FiscalYear_Id")]
        public FiscalYear FiscalYear { get; set; }

        public int Month_Id { get; set; }
        [ForeignKey("Month_Id")]
        public Month Month { get; set; }
        public int Analytical_skills { get; set; }
        public int Ability_to_work_Under_pressure_and_Multi_Tasking_skills { get; set; }
        public int Accuracy_Efficiency_and_Time_Management { get; set; }
        public int Oral_and_Written_Commuinication_Skills { get; set; }
        public int Collaboration_and_Team_work { get; set; }
        public int Dressing_Code_and_Attendance { get; set; }
        public int Knowledge_of_the_Job_and_Initiative_to_learn { get; set; }
        public int Confidentiality_Honesty_Integertiy { get; set; }
        public int Innovation_and_Problem_Solving_Skills { get; set; }
        public int Attitude_toward_Internal_and_External_customers_Collagues_and_the_Bank { get; set; }
        public decimal TotalQuarterly { get; set; }
        public string Additional_Comment_or_sugesstion_by_Supervisor { get; set; }
        public string Employes_Comment_on_Evaluation {get;set;}
        public string Name_of_Employee { get; set; }
        public string Employee_signature { get; set; }
        public DateTime Employee_SignedDate { get; set; }
        public string Name_of_Supervisor { get; set; }
        public string Supervisor_signature { get; set; }
        public DateTime Supevisor_ApprovedDate { get; set; }//Date
        public bool IsEmployeeApproved { get; set; }
        public bool IsSupervisorApproved { get; set; }
     

    }
}
