using System.Data;
using System.Data.SQLite;
using Dapper;

namespace SocialNetwork.DAL.Repositories;

public class BaseRepository
{
    protected T QueryFirstOrDefault<T>(string sql, object parameters = null)
        {
            using (var connection = CreateConnection())
            {
                connection.Open();
                return connection.QueryFirstOrDefault<T>(sql, parameters);
            }
        }

        protected List<T> Query<T>(string sql, object parameters = null)
        {
            using (var connection = CreateConnection())
            {
                connection.Open();
                return connection.Query<T>(sql, parameters).ToList();
            }
        }

        protected int Execute(string sql, object parameters = null)
        {
            using (var connection = CreateConnection())
            {
                connection.Open();
                return connection.Execute(sql, parameters);
            }
        }

        private IDbConnection CreateConnection()
        {
            return new SQLiteConnection("Data Source = /home/admina/Документы/C-sharp курс/module19/SocialNetwork.DAL/DB/social_network.db; Version = 3");
            //return new SQLiteConnection("Data Source = |DataDirectory|/DB/social_network.db; Version = 3");
            ///home/admina/Документы/C-sharp курс/module19/SocialNetwork.DAL/DB/social_network.db
            //SocialNetwork.DAL/DB/social_network.db
        }
}