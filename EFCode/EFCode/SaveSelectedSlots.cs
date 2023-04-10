using System.Data.SqlClient;

namespace EFCode
{
    public class SaveSelectedSlots
    {
        public void ConnectToDatabase(DateTime date, string[] timeSlots, string name)
        {
            string connectionString = "Data Source=DESKTOP-AGRLESG\\SQLEXPRESS;Initial Catalog=UniversityTutoringWebsiteDatabase;Integrated Security=SSPI;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Open the connection
                connection.Open();
                foreach (string timeSlot in timeSlots)
                {
                    var command = new SqlCommand("INSERT INTO TimeSlots (time_slot, dateselected, Tutor_Name) VALUES (@timeSlots, @date, @name)", connection);
                    command.Parameters.AddWithValue("@timeSlots", timeSlot);
                    command.Parameters.AddWithValue("@date", date);
                    command.Parameters.AddWithValue("@name", name);
                    command.ExecuteNonQuery();
                }

                connection.Close();

                // return dataList;

            }
        }
    }
}
