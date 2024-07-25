using PerMS.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace PerMS
{
    public class MonthlyPmsWeight
    {
        public int Id { get; set; }
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

    }
}
