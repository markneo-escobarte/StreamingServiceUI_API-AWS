using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reflection.Metadata.Ecma335;
using System.Reflection.PortableExecutable;
using StreamingServiceModel;

namespace StreamingServiceDL
{
    public class SqlDbData
    {
        static string connectionString
        = "Data Source = LAPTOP-78G5SIK7\\SQLEXPRESS; Initial Catalog = StreamingService; Integrated Security = True;";
        //= "Server = tcp:20.2.89.26,1433;Database= StreamingService;User Id= sa;Password= Rureuo@7172003";

        static SqlConnection sqlConnection = new SqlConnection(connectionString);

        public static void Connect()
        {
            sqlConnection.Open();
        }

        private readonly EmailTool _emailTool;

        public SqlDbData()
        {
            _emailTool = new EmailTool();
        }

        public List<User> GetTitle()
        {
            List<User> users = new List<User>();

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string selectStatement = "SELECT title FROM users";
                SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);

                sqlConnection.Open();

                using (SqlDataReader reader = selectCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        User user = new User()
                        {

                            Title = reader["title"].ToString()
                        };

                        users.Add(user);
                    }

                    return users;
                }
            }
        }

        public void AddTitle(User user)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string insertStatement = "INSERT INTO users (Title) VALUES (@title)";

                SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection);


                insertCommand.Parameters.AddWithValue("@title", user.Title);
                sqlConnection.Open();

                insertCommand.ExecuteNonQuery();


            }

            _emailTool.SendEmail("Movie Added to Watchlist", $"You have successfully added '{user.Title}' to your watchlist.");

        }
        public void DeleteTitle(string title)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string deleteStatement = $"DELETE FROM users WHERE title = @title";
                SqlCommand deleteCommand = new SqlCommand(deleteStatement, sqlConnection);


                deleteCommand.Parameters.AddWithValue("@title", title);

                sqlConnection.Open();

                deleteCommand.ExecuteNonQuery();

                sqlConnection.Close();
            }

            _emailTool.SendEmail("Movie Deleted from Watchlist", $"You have successfully deleted '{title}' from your watchlist.");

        }

        public void UpdateTitle(string oldTitle, string newTitle)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string updateStatement = "UPDATE users SET title = @newTitle WHERE title = @oldTitle";
                SqlCommand updateCommand = new SqlCommand(updateStatement, sqlConnection);

                updateCommand.Parameters.AddWithValue("@newTitle", newTitle);
                updateCommand.Parameters.AddWithValue("@oldTitle", oldTitle);

                sqlConnection.Open();
                updateCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }

            _emailTool.SendEmail("Movie Updated in Watchlist", $"You have successfully updated '{oldTitle}' to '{newTitle}' in your watchlist.");

        }


    }

}