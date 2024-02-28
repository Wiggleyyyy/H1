using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace csharp_gambling
{
    internal class Database
    {
        private string dbName = "CasinoDB";
        private string dbDataSource = "localhost";
        private string dbUserID = "ConnectionUser";
        private string dbPassword = "AppConnection!";

        private string connectionString;
        private SqlConnection cnn;

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
                MessageBox.Show("Kunne ikke oprette forbindelse til database", "Fejl", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                cnn.Close();
            }
        }

        public bool Signup(string username, string password)
        {
            try
            {
                //Open connection to database
                connectionString = $@"Data Source={dbDataSource},1434;Initial Catalog={dbName};User ID={dbUserID};Password={dbPassword};Integrated Security=True"; // *1434* = 
                cnn = new SqlConnection(connectionString);
                cnn.Open();

                //Check if username already exists
                string checkQuery = "SELECT COUNT(*) FROM Main WHERE username = @Username";
                SqlCommand checkCommand = new SqlCommand(checkQuery, cnn);
                checkCommand.Parameters.AddWithValue("@Username", username);
                int existingUsersCount = (int)checkCommand.ExecuteScalar();

                if (existingUsersCount > 0)
                {
                    MessageBox.Show("Brugernavn findes allerede. Indtast et nut brugernavn.", "Fejl", MessageBoxButtons.OK, MessageBoxIcon.Error );
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
                MessageBox.Show(ex.Message);
                MessageBox.Show("Kunne ikke oprette forbindelse til database", "Fejl", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                cnn.Close();
            }
        }
    }
}
