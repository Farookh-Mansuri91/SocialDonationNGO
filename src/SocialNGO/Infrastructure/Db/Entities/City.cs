namespace SocialNGO.Infrastructure.Db.Entities
{
    public class City : BaseEntity
    {
        public string CityName { get; set; }
        public int StateId { get; set; }
    }
}
