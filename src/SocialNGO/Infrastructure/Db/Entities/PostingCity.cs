namespace SocialNGO.Infrastructure.Db.Entities
{
    public class PostingCity:BaseEntity
    {
        public string CityName { get; set; }
        public int StateId { get; set; }
    }
}
