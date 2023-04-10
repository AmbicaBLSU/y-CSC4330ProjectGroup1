using EFCode.Models;
using System.Data.SqlClient;

namespace EFCode
{
    public class RequestStatusSubmission
    {
        public void ConnectToDatabase(SlotsViewModel model)
        {
            string connectionString = "Data Source=DESKTOP-AGRLESG\\SQLEXPRESS;Initial Catalog=UniversityTutoringWebsiteDatabase;Integrated Security=SSPI;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Open the connection
                connection.Open();

                //SqlCommand command1 = new SqlCommand("INSERT INTO tutorRequests (RequestStatus) VALUES (@RequestStatus)", connection);
                //command1.Parameters.AddWithValue("@RequestStatus", model.RequestStatus);
                //command1.ExecuteNonQuery();
                //SqlCommand command2 = new SqlCommand("UPDATE tutorRequests SET RequestStatus = @RequestStatus WHERE RequestId = @RequestId", connection);
                for (int i = 0; i < model.studentsUnameList.Count; i++)
                {
                    SqlCommand command2 = new SqlCommand("insert into TutorRequestsStatus values (@date,@slots,@username,@status,@tutorusername)", connection);

                    command2.Parameters.AddWithValue("@date", model.studentrequestsDates[i]);
                    command2.Parameters.AddWithValue("@slots", model.studentrequestsSlots[i]);
                    command2.Parameters.AddWithValue("@username", model.studentsUnameList[i]);
                    command2.Parameters.AddWithValue("@status", model.Requests[i]);
                    command2.Parameters.AddWithValue("@tutorusername", model.TutorUserName[i]);


                    //command2.Parameters.AddWithValue("@RequestId", model.RequestId[1]);
                    //command.Parameters.AddWithValue("@Pwd", model.Password);

                    //connection.Open();
                    command2.ExecuteNonQuery();
                    SqlCommand command3 = new SqlCommand("delete from StudentRequest where professorname = @pname and studentusername = @sname and SlotDate = @dt and timeslot = @slt", connection);
                    //delete from StudentRequest where professorname = 'lkunku' and studentusername = 'abanch1' and SlotDate = '2023-04-11 00:00:00.000' and timeslot = '18:00:00'
                    command3.Parameters.AddWithValue("@pname", model.TutorUserName[i]);
                    command3.Parameters.AddWithValue("@sname", model.studentsUnameList[i]);

                    command3.Parameters.AddWithValue("@dt", model.studentrequestsDates[i]);

                    command3.Parameters.AddWithValue("@slt", model.studentrequestsSlots[i]);

                    //SqlCommand command = new SqlCommand("SELECT SlotDate,timeslot,professorname,studentusername from StudentRequest where professorname=@TutorName", connection);
                    command3.ExecuteNonQuery();

                    SqlCommand command4 = new SqlCommand("update StudentRequestwithstatus set appointmentstatus=@status where professorname = @pname and studentusername = @sname and SlotDate = @dt and timeslot = @slt", connection);
                    //delete from StudentRequest where professorname = 'lkunku' and studentusername = 'abanch1' and SlotDate = '2023-04-11 00:00:00.000' and timeslot = '18:00:00'
                    command4.Parameters.AddWithValue("@pname", model.TutorUserName[i]);
                    command4.Parameters.AddWithValue("@status", model.Requests[i]);
                    command4.Parameters.AddWithValue("@sname", model.studentsUnameList[i]);

                    command4.Parameters.AddWithValue("@dt", model.studentrequestsDates[i]);

                    command4.Parameters.AddWithValue("@slt", model.studentrequestsSlots[i]);

                    //SqlCommand command = new SqlCommand("SELECT SlotDate,timeslot,professorname,studentusername from StudentRequest where professorname=@TutorName", connection);
                    command4.ExecuteNonQuery();
                }

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
