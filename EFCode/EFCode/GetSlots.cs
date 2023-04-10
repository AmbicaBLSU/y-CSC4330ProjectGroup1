using EFCode.Models;
using System.Data.SqlClient;

namespace EFCode
{
    public class GetSlots
    {
        public List<string> ConnectToDatabase(DateTime date,string tutorname)
        {
            string connectionString = "Data Source=DESKTOP-AGRLESG\\SQLEXPRESS;Initial Catalog=UniversityTutoringWebsiteDatabase;Integrated Security=SSPI;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Open the connection
                connection.Open();
                List<string> slots = new List<string>();

                // Prepare the SQL command to check the credentials
                SqlCommand command = new SqlCommand("SELECT time_slot FROM TimeSlots where dateselected=@date and Tutor_Name =@tutorname", connection);
                 command.Parameters.AddWithValue("@date", date);
                command.Parameters.AddWithValue("@tutorname", tutorname);
                //command.Parameters.AddWithValue("@password", password);

                // Execute the command and get the result
                // int count = (int)command.ExecuteScalar();

                // Close the connection
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    var timeSlots = new List<string>();

                    while (reader.Read())
                    {
                        timeSlots.Add(reader.GetString(0));
                        /*var timeSlot = new TimeSlot
                        {
                            //Date = reader.GetDateTime(0),
                            Time = reader.GetString(0)
                        };

                        timeSlots.Add(reader.GetString(0));
                        */
                    }

                    return timeSlots;
                }


                connection.Close();

                //return dataList;

            }
            
        }
    }
}
