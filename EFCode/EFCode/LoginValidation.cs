using System.Data.SqlClient;
using System.Configuration;
//using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
//using System.Web.Mvc;

namespace EFCode
{
    /* public class LoginValidation
     {
         string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;


      using (SqlConnection connection = new SqlConnection(connectionString))
         {
             // Open the connection
             connection.Open();

             // Execute a SQL command
             SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM MyTable", connection);
     int count = (int)command.ExecuteScalar();

     // Print the result
     Console.WriteLine($"There are {count} rows in the MyTable table.");

             // Close the connection
             connection.Close();
         }

 // Execute a SQL command
 SqlCommand command = new SqlCommand("SELECT * FROM MyTable", connection);
         SqlDataReader reader = command.ExecuteReader();

 // Process the results
 while (reader.Read())
 {
     int id = (int)reader["Id"];
         string name = (string)reader["Name"];
         // Do something with the data...
     }

     // Close the reader and connection
     reader.Close();
 connection.Close();
     }*/
    public class LoginValidation
    {
        public string ConnectToDatabase(string username, string password)
        {
            string connectionString = "Data Source=DESKTOP-AGRLESG\\SQLEXPRESS;Initial Catalog=UniversityTutoringWebsiteDatabase;Integrated Security=SSPI;";
            // Define the connection string
            /*string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;

            // Create a SqlConnection object with the connection string
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Open the connection
                connection.Open();

                // Execute a SQL command
                SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM UserCredentials", connection);
                int count = (int)command.ExecuteScalar();

                // Print the result
                Console.WriteLine($"There are {count} rows in the UserCredentials table.");
                SqlDataReader reader = command.ExecuteReader();

                // Process the results
                while (reader.Read())
                {
                    int id = (int)reader["username"];
                    string name = (string)reader["pwd"];
                    // Do something with the data...
                }

                // Close the reader and connection
                reader.Close();
                // Close the connection
                connection.Close();
            }*/
            //string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Mydbconn"]?.ConnectionString;
            //var test=System.Configuration.ConfigurationManager.AppSettings;

            // Create a SqlConnection object with the connection string
            string value1 = "";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Open the connection
                connection.Open();

                // Prepare the SQL command to check the credentials
                SqlCommand command = new SqlCommand("SELECT UserType FROM UserRegistration WHERE username = @username AND pwd = @password", connection);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);
                //int count = (int)command.ExecuteScalar();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // read the values from the columns and add them to the list
                        value1 = reader.GetString(0);
                        // Execute the command and get the result

                    }

                    // Close the connection
                    connection.Close();

                    // Check if the credentials are valid
                    //if (count == 1)
                    //{
                    // Redirect to the home page or a success page
                    //return RedirectToAction("Index", "Home");
                    return value1;
                    //}
                    //else
                    //{
                    // Add an error message to the model state
                    //ModelState.AddModelError("", "Invalid username or password.");
                    //  return 0;
                    //}
                }

                // If we got this far, something went wrong
                //return View();
            }
        }
    }
}

