using OnlineMovieTicket.Entity;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
namespace OnlineMovieTicket.DAL
{
    public class UserRepository
    {
        public static bool Login(string mailId, string password)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            string sqlCommand = "User_Proc_Signin";
            SqlCommand command = new SqlCommand(sqlCommand, sqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            sqlConnection.Open();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if ((reader.GetString(0) == mailId) && (reader.GetString(1) == password))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        public static bool Insert(UserEntity user)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            string sqlCommand = "User_Proc_SignUp";
            using (SqlCommand command = new SqlCommand(sqlCommand, sqlConnection))
            {
                command.CommandType = CommandType.StoredProcedure;
                try
                {
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
                }
                catch (Exception)
                {
                    Console.WriteLine("Exception thrown");
                }
                finally
                {
                    command.Dispose();
                    sqlConnection.Close();
                }
            }
            return false;
        }
        public static DataTable Refreshdata()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("select * from Movie", sqlConnection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            return dt;
        }
        public static void RowDeleting(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                sqlConnection.Open();
                string sqlCommand = "SP_Delete";
                SqlCommand cmd = new SqlCommand(sqlCommand, sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception caught");
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public static void RowUpdating(string txtMovie,int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                using (SqlCommand cmd = new SqlCommand("SP_Update", sqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Movie", txtMovie);
                    cmd.Parameters.AddWithValue("@id", id);
                    int i = cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
