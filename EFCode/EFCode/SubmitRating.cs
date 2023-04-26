using System.Data.SqlClient;

namespace EFCode
{
    public class SubmitRating
    {
        public void ConnectToDatabase(string Name, decimal rating)
        {
            string connectionString = "Data Source=DESKTOP-AGRLESG\\SQLEXPRESS;Initial Catalog=UniversityTutoringWebsiteDatabase;Integrated Security=SSPI;MultipleActiveResultSets=true";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Open the connection
                connection.Open();
                List<string> dataList = new List<string>();
                List<string> dataList2 = new List<string>();

                // Prepare the SQL command to check the credentials
                SqlCommand command = new SqlCommand("SELECT rating from UserRegistration where Username=@Name", connection);
                command.Parameters.AddWithValue("@Name", Name);
                //command.Parameters.AddWithValue("@password", password);

                // Execute the command and get the result
                // int count = (int)command.ExecuteScalar();

                // Close the connection
                decimal value=0;
                decimal UpdatedRating =0;
                SqlDataReader reader = command.ExecuteReader();
                //{
                while (reader.Read())
                {
                    // read the values from the columns and add them to the list
                    //DateTime value1 = reader.GetDateTime(0);
                    value = reader.GetDecimal(0);
                UpdatedRating = (decimal)((value + rating) / 2);
                //string value3 = reader.GetString(2);
                //string value4 = reader.GetString(4);
                //dataList.Add(value1);
                //dataList.Add(value2);
                //dataList.Add(value3);
                //dataList.Add(value1);
                //string value3=reader.GetValue
                // dataList.Add("Your appointment for date: " + value1 + " at " + value2 + " slot " + " with tutor: " + value3 + " is " + value4);
                //datalist1.Add(value1.ToString());
                ////datalist1.Add(value2);
                //datalist1.Add(value3);
                //datalist1.Add(TutorName);
                //ConnectToDatabase3(dataList2);

                 }
                SqlCommand command1 = new SqlCommand("update UserRegistration set rating= @rating where Username=@Name", connection);
                command1.Parameters.AddWithValue("@rating", UpdatedRating);
                command1.Parameters.AddWithValue("@Name", Name);
                //command.Parameters.AddWithValue("@password", password);

                // Execute the command and get the result
                // int count = (int)command.ExecuteScalar();

                // Close the connection
                // int value = 0;
                //double UpdatedRating = 0.00;
                SqlDataReader reader1 = command1.ExecuteReader();



                connection.Close();

                //return UpdatedRating;

            }
        }
    }
}
