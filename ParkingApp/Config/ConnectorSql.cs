using System.Data.SqlClient;

namespace ParkingApp.Config
{
    public class ConnectorSql
    {
        private string stringSQL = string.Empty;

        public ConnectorSql()
        {


            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            stringSQL = builder.GetSection("ConnectionStrings:CadenaSQL").Value;
        }

        public string getStringSQL()
        {
            return stringSQL;
        }


    }
}
