using OnlineMovieTicket.Entity;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
namespace OnlineMovieTicket.DAL
{
    public class UserRepository
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        static SqlConnection sqlConnection = new SqlConnection(connectionString);
        public static bool Login(string mailId, string password)
        {
            string sqlCommand = "SP_Signin";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlCommand, sqlConnection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@MailId", mailId);
                command.Parameters.AddWithValue("@UserPassword", password);
                sqlConnection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                        return true;
                    else
                        return false;
                }
            }

        }
        public static bool Register(UserEntity user)
        {
            string sqlCommand = "SP_SignUp";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlCommand, sqlConnection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@firstName", user.firstName);
                command.Parameters.AddWithValue("@lastName", user.secondName);
                command.Parameters.AddWithValue("@mobileNumber", user.mobileNumber);
                command.Parameters.AddWithValue("@mailId", user.mailId);
                command.Parameters.AddWithValue("@password", user.password);
                command.Parameters.AddWithValue("@confirmPassword", user.confirmPassword);
                sqlConnection.Open();
                int rows = command.ExecuteNonQuery();
                if (rows >= 1)
                    return true;
                else
                    return false;
            }

        }
        public static DataTable Refreshdata()
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("select * from Movie", sqlConnection);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                return dt;
            }
        }
        public static void RowDeleting(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string sqlCommand = "SP_Delete";
                using (SqlCommand cmd = new SqlCommand(sqlCommand, sqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);
                    sqlConnection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static void RowUpdating(string txtMovie, int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_Update", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Movie", txtMovie);
                cmd.Parameters.AddWithValue("@id", id);
                sqlConnection.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public static void RowInserting(string movieName)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_Insert", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Movie", movieName);
                sqlConnection.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}

