
using LevelsDAL.Models;
using System.Data.Entity;
using System.Data.SqlClient;

namespace LevelsDAL.EF
{
    public class LevelsDAL : DbContext
    {
        public DbSet<Level> Levels => Set<Level>();

        public LevelsDAL():base("Server=DESKTOP-N76QD8J\\SQLEXPRESS;Database=MathGameLevels;Trusted_Connection=True;Encrypt=False;")
            //Server=DESKTOP-N76QD8J\SQLEXPRESS;Database=MathGameLevels;Trusted_Connection=True;Encrypt=False;
            //Server=(localdb)\\mssqllocaldb;Database=MathGameLevels;Trusted_Connection=True;
        {
        }

        public static string GetRemoteConnectionString()
        {
            int IP = 0;
            int PORT = 0;
            SqlConnectionStringBuilder sqlString = new SqlConnectionStringBuilder()
            {
                DataSource = $"{IP},{PORT}", // ex : 37.59.110.55,1433 
                InitialCatalog = "MyDatabaseName",  //Database
                IntegratedSecurity = false,
                MultipleActiveResultSets = true,
                ApplicationName = "EntityFramework",
                UserID = "MyUserId",
                Password = "MyPassword"
            };
            return sqlString.ToString();
        }
    }
}
