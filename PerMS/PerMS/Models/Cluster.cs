using PerMS.Models;

namespace PerMS
{
    public class Cluster
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int DistrictID { get; set; }
        public District Districts { get; set; } // A business unit can have many users
        public ICollection<BussinesUnit> BussinesUnits { get; set; } // A business unit can have many users

    }
}
