namespace PerMS.Models
{
    public class FiscalYear
    {
       public int Id { get; set; }
      public int FiscalYear_Year { get; set; }
      public DateTime FiscalYear_StartDate { get; set; }
      public DateTime FiscalYear_EndDate { get; set; }
      public bool FiscalYear_Closed { get; set; }
      public bool FiscalYear_IsCurrentYear { get; set; }
    }
}
