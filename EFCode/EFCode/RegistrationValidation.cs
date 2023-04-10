using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Data.SqlClient;
using System.Configuration;
//using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Web.Mvc;
using EFCode.Models;

namespace EFCode
{
    public class RegistrationValidation
    {
        public void ConnectToDatabase(RegisterViewModel model)
        {
            string connectionString = "Data Source=DESKTOP-457128\\SQLEXPRESS;Initial Catalog=UniversityTutoringWebsiteDatabase;Integrated Security=SSPI;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Open the connection
                connection.Open();

                // Prepare the SQL command to check the credentials
                //SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM UserCredentials WHERE username = @username AND pwd = @password", connection);
                //SqlCommand command = new SqlCommand("INSERT INTO UserRegistration VALUES ()SELECT COUNT(*) FROM UserCredentials WHERE username = @username AND pwd = @password", connection);
                SqlCommand command = new SqlCommand("INSERT INTO UserRegistration (FirstName,LastName,Username,Pwd,DOB,EmailId,UserType) VALUES (@Fn,@Ln,@Username,@Pwd,@dob,@email,@usertype)", connection);
                command.Parameters.AddWithValue("@Username", model.Username);
                command.Parameters.AddWithValue("@Pwd", model.Password);
                command.Parameters.AddWithValue("@Email", model.Email);
                command.Parameters.AddWithValue("@Fn", model.FirstName);
                command.Parameters.AddWithValue("@Ln", model.LastName);
                command.Parameters.AddWithValue("@dob", model.DateOfBirth);
                command.Parameters.AddWithValue("@usertype", model.UserType);
               // command.Parameters.AddWithValue("@Pwd", model.Password);

                //connection.Open();
                command.ExecuteNonQuery();



                //command.Parameters.AddWithValue("@username", username);
                //command.Parameters.AddWithValue("@password", password);

                // Execute the command and get the result
                //int count = (int)command.ExecuteScalar();

                // Close the connection
                connection.Close();

                // Check if the credentials are valid
                //if (count == 1)
                //{
                // Redirect to the home page or a success page
                //return RedirectToAction("Index", "Home");
                //return count;
                //}
                //else
                //{
                // Add an error message to the model state
                //ModelState.AddModelError("", "Invalid username or password.");
                //  return 0;
                //}
            }
        }
    }
}
