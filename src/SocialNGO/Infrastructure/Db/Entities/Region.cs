namespace SocialNGO.Infrastructure.Db.Entities
{
    public class Region:   BaseEntity
    {
        public string RegionName { get; set; }
        public int CountryId { get; set; }

    }
}
