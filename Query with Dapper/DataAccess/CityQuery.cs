namespace Query_with_Dapper.DataAccess
{
    public class CityQuery
    {
        public string ConnectionString { get; set; }
        public CityQuery()
        {
            string password = Secret.DbPassword();
            ConnectionString = $"server=localhost;database=world;password={password};user=root;AllowUserVariables=true\\";
        }



    }
}