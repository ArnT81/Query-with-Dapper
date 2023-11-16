using Dapper;
using MySqlConnector;
using Newtonsoft.Json.Linq;
using Query_with_Dapper.Models;
using System.Collections.Generic;
using System.Data;

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
            try
            {

                using (var connection = new MySqlConnection(ConnectionString))
                {
                    city = connection.QueryFirst<CityDetails>(q, new { id });
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }


            return city;
        }

        public List<CityDetails> GetCityByPopulation(int min, int max)
        {
            List<CityDetails> cities = new List<CityDetails>();
            string q = "SELECT * FROM city WHERE population BETWEEN @min AND @max";

            using (var connection = new MySqlConnection(ConnectionString))
            {
                cities = connection.Query<CityDetails>(q, new { min, max }).ToList();
            }

            return cities;
        }


        public List<CityDetails> GetCityWithLimitation(int limit)
        {
            List<CityDetails> cities = new List<CityDetails>();
            string q = "SELECT * FROM city LIMIT @limit";

            using (var connection = new MySqlConnection(ConnectionString))
            {
                cities = connection.Query<CityDetails>(q, new { limit }).ToList();
            }

            return cities;
        }




        public List<City> GetCitiesByCountrycode(string countrycode)
        {
            string q = "SELECT Id, Name FROM city WHERE countrycode = @countrycode";

            using (var connection = new MySqlConnection(ConnectionString))
            {
                Cities = connection.Query<City>(q, new { countrycode }).ToList();
            }

            return Cities;
        }







        public List<CityDetails> GetCitiesInEuropeByLifeExpectancy()
        {
            List<CityDetails> cities = new List<CityDetails>();
            string q = "SELECT Id, Name FROM city WHERE countrycode = @countrycode";

            using (var connection = new MySqlConnection(ConnectionString))
            {
                cities = connection.Query<CityDetails>(q).ToList();
            }

            return cities;
        }








        public CityDetails CreateCity(string name, int population, string countryCode, string district)
        {
            CityDetails city = new CityDetails();
            string q = "INSERT INTO city (Name, Population, CountryCode, District)" +
                       "VALUES(@name, @population, @countryCode, @district)";

            try
            {
                using (var connection = new MySqlConnection(ConnectionString))
                {
                    city = connection.QueryFirst<CityDetails>(q, new { name, population, countryCode, district });
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return city;
        }
    }
}