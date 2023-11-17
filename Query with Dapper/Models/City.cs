using System.ComponentModel.DataAnnotations;

namespace Query_with_Dapper.Models
{
    public class City
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Population { get; set; }
    }

    public class CityDetails : City
    {
        public string? CountryCode { get; set; }
        public string? District { get; set; }
        public int? LifeExpectancy { get; set; }
    }
}