using System.Data.SqlClient;

namespace EFCode
{
    public class StudentAppointmentStatus
    {
        public List<string> ConnectToDatabase(string TutorName)
        {
            string connectionString = "Data Source=DESKTOP-67854\\SQLEXPRESS;Initial Catalog=UniversityTutoringWebsiteDatabase;Integrated Security=SSPI;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Open the connection
                connection.Open();
                List<string> dataList = new List<string>();
                List<string> dataList2 = new List<string>();

                // Prepare the SQL command to check the credentials
                SqlCommand command = new SqlCommand("SELECT SlotDate,timeslot,professorname,studentusername,appointmentstatus from StudentRequestwithstatus where studentusername=@Name", connection);
                command.Parameters.AddWithValue("@Name", TutorName);
                //command.Parameters.AddWithValue("@password", password);

                // Execute the command and get the result
                // int count = (int)command.ExecuteScalar();

                // Close the connection
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // read the values from the columns and add them to the list
                        DateTime value1 = reader.GetDateTime(0);
                        string value2 = reader.GetString(1);
                        string value3 = reader.GetString(2);
                        string value4 = reader.GetString(4);
                        //dataList.Add(value1);
                        //dataList.Add(value2);
                        //dataList.Add(value3);
                        //dataList.Add(value1);
                        //string value3=reader.GetValue
                        dataList.Add("Your appointment for date: " + value1 + " at " + value2 + " slot " + " with tutor: " + value3 + " is " + value4);
                        //datalist1.Add(value1.ToString());
                        ////datalist1.Add(value2);
                        //datalist1.Add(value3);
                        //datalist1.Add(TutorName);
                        //ConnectToDatabase3(dataList2);

                    }
                }


                connection.Close();

                return dataList;

            }
        }
        }
    }
