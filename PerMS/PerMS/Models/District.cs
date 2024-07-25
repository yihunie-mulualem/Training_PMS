namespace PerMS.Models
{
        public class District
        {
            public int Id { get; set; }
            public string Code { get; set; }
            public string Name { get; set; }
            public ICollection<Cluster> Clusters { get; set; }
                                                           // A business unit can have many users
    }


}
