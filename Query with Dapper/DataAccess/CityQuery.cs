using Dapper;
using MySqlConnector;
using Query_with_Dapper.Models;

namespace Query_with_Dapper.DataAccess
{
    public class CityQuery
    {
        public string ConnectionString { get; set; }
        public List<City> Cities = new List<City>();

        public CityQuery()
        {
            string password = Secret.DbPassword();
            ConnectionString = $"server=localhost;database=world;password={password};user=root;AllowUserVariables=true";
        }


        public CityDetails GetCityById(int id)
        {
            CityDetails city = new CityDetails();
            string q = "SELECT * FROM city WHERE Id = @id";

            using (var connection = new MySqlConnection(ConnectionString))
            {
                city = connection.QueryFirst<CityDetails>(q, new { Id = id });
            }

            return city;
        }


        public List<City> GetCitiesByCountrycode(string code)
        {
            string q = "SELECT Id, Name, Population FROM city WHERE countrycode = @countrycode";

            using (var connection = new MySqlConnection(ConnectionString))
            {
                Cities = connection.Query<City>(q, new { countrycode = code }).ToList();
            }

            return Cities;
        }
    }
}