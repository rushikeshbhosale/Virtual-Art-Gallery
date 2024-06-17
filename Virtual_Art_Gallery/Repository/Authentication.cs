using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Virtual_Art_Gallery.Utility;
using Virtual_Art_Gallery.Models;

namespace Virtual_Art_Gallery.Repository
{
    internal class Authentication
    {
        SqlConnection connect = null;
        SqlCommand cmd = null;
        public Authentication()
        {
            connect = new SqlConnection(DataConnectionUtility.GetConnectionString());
            cmd = new SqlCommand();
        }

        public bool Login(string username, string password)
        {
            int count = 0;
            try
            {
                cmd.CommandText = "SELECT count(*) as match FROM [USER] WHERE Username = @username AND [Password] = @password";
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                connect.Open();
                cmd.Connection = connect;
                SqlDataReader reader = cmd.ExecuteReader();
                cmd.Parameters.Clear();
                while (reader.Read())
                {
                    count = (int)reader["match"];
                }
                connect.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return count > 0;
        }

        public bool Register(User user)
        {
            int status = 0;
            try
            {
                cmd.CommandText = "INSERT INTO [USER] (Username, [Password], Email, [First Name], [Last Name], [Date of Birth], [Profile Picture]) VALUES (@username, @password, @email, @fname, @lname, @dob, @profile)";
                cmd.Parameters.AddWithValue("@username", user.Username);
                cmd.Parameters.AddWithValue("@password", user.Password);
                cmd.Parameters.AddWithValue("@email", user.Email);
                cmd.Parameters.AddWithValue("@fname", user.FirstName);
                cmd.Parameters.AddWithValue("@lname", user.LastName);
                cmd.Parameters.AddWithValue("@dob", user.DateOfBirth);
                cmd.Parameters.AddWithValue("@profile", user.ProfilePicture);
                connect.Open();
                cmd.Connection = connect;
                status = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                connect.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return status > 0;
        }
    }
}
