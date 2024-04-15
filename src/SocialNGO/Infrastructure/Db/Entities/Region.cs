namespace SocialNGO.Infrastructure.Db.Entities
{
    public class Region
    {
        public  int RegionId { get; set; }
        public string RegionName { get; set; }

        public int CountryId { get; set; }

    }
}
