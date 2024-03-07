using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Gambling2ElectricBogaloo.Components.Classes.Database
{
    public class Database
    {
        private string dbName = "CasinoDB";
        private string dbDataSource = "localhost";  
        private string dbUserID = "ConnectionUser";
        private string dbPassword = "AppConnection!";

        private string connectionString;
        private SqlConnection cnn;

        public string errorMessage;

        //public void connectToDatabase()
        //{
        //    try
        //    {
        //        //Open connection to database
        //        connectionString = $@"Data Source={dbDataSource},1434;Initial Catalog={dbName};User ID={dbUserID};Password={dbPassword};Integrated Security=True"; // *1434* = 
        //        cnn.Open();


        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Kunne ikke oprette forbindelse til database", "Fejl", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        public bool Login(string username, string password)
        {
            errorMessage = null;
            try
            {
                //Open connection to database
                connectionString = $@"Data Source={dbDataSource},1434;Initial Catalog={dbName};User ID={dbUserID};Password={dbPassword};Integrated Security=True"; // *1434* = 
                cnn = new SqlConnection(connectionString);
                cnn.Open();

                string query = "SELECT COUNT(*) FROM Main WHERE username = @Username AND password = @Password";
                SqlCommand command = new SqlCommand(query, cnn);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);
                int count = (int)command.ExecuteScalar();

                return count > 0; //If count > 0, login in successful
            }
            catch (Exception e)
            {
                errorMessage = "An error occurred while attempting to log in.";
                Console.WriteLine(e.Message);
                return false;
            }
            finally
            {
                cnn.Close();
            }
        }

        public bool Signup(string username, string password)
        {
            errorMessage = null;
            try
            {
                //Open connection to database
                connectionString = $@"Data Source={dbDataSource};Initial Catalog={dbName};User ID={dbUserID};Password={dbPassword};Integrated Security=True"; // *1434* = 
                cnn = new SqlConnection(connectionString);
                cnn.Open();

                //Check if username already exists
                string checkQuery = "SELECT COUNT(*) FROM Main WHERE username = @Username";
                SqlCommand checkCommand = new SqlCommand(checkQuery, cnn);
                checkCommand.Parameters.AddWithValue("@Username", username);
                int existingUsersCount = (int)checkCommand.ExecuteScalar();

                if (existingUsersCount > 0)
                {
                    errorMessage = "User already exists";
                    return false;
                }

                string query = "INSERT INTO Main (balance, username, password) VALUES (100, @Username, @Password)";
                SqlCommand command = new SqlCommand(query, cnn);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);
                int rowsAffected = command.ExecuteNonQuery();

                return rowsAffected > 0; //If rows affected > 0, user was created

            }
            catch (Exception ex)
            {
                errorMessage = "An error occurred while attempting to sign up.";
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                cnn.Close();
            }
        }

        public double GetCurrentBalance(string username)
        {
            errorMessage = null;
            try
            {
                //Open connection to database
                connectionString = $@"Data Source={dbDataSource};Initial Catalog={dbName};User ID={dbUserID};Password={dbPassword};Integrated Security=True"; // *1434* = 
                cnn = new SqlConnection(connectionString);
                cnn.Open();

                string query = "SELECT balance FROM Main WHERE username = @Username";
                SqlCommand command = new SqlCommand(query, cnn);
                command.Parameters.AddWithValue("@Username", username);

                object result = command.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    return (double)Convert.ToDouble(result);
                }
                else
                {
                    return -1;
                }
            }
            catch (Exception ex)
            {
                errorMessage = "An error occurred while attempting to connect to the database";
                Console.WriteLine(ex.Message);
                return -1;
            }
            finally
            {
                cnn.Close();
            }
        }
    }
}