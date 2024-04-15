namespace SocialNGO.Infrastructure.Db.Entities
{
    public class Address
    {
        public int AddressId { get; set; }
        public string Street { get; set; }
        public string BlockName { get; set; }
        public string PostalCode { get; set; }
        public int CityId { get; set; }

    }
}
