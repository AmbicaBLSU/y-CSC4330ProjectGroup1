using EFCode.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System.Collections;
using System.Diagnostics;
using System.Text.Json;

namespace EFCode.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public static string MyVariable = "";
        public static string MyVariable1 = "";

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Homepage()
        
        {
            if (TempData.TryGetValue("ErrorMessage", out object errorMessage))
            {
                // There's an error message, so display it to the user.
                ViewBag.ErrorMessage = errorMessage;
            }
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
        /*   public IActionResult Registration()
           {
               return View();
           }
        */
        public IActionResult SelectedDate(DateTime date,string tutorname)
        {
            GetSlots s = new GetSlots();
            s.ConnectToDatabase(date,tutorname);
            return View();
        }
        public IActionResult CoordinatorViewProfessor(SlotsViewModel model, string StudentName)
        {
            model.StudentUserName = MyVariable;
            RegistrationValidation s = new RegistrationValidation();
            //var timeSlots = s.ConnectToDatabase(model);
            List<decimal> l = new List<decimal>();

            l = s.ConnectToDatabase1();

            //model.StudentUserName = StudentName;
            ViewBag.Balance = l;
            return View(model);

            //return RedirectToAction("Homepage", "Home");
        }
        
        public IActionResult ViewProfessors(SlotsViewModel model, string StudentName)
        {
            model.StudentUserName = MyVariable;
            RegistrationValidation s = new RegistrationValidation();
            List<object> l5= s.ConnectToDatabase5();
            
            //var timeSlots = s.ConnectToDatabase(model);
            List<decimal> l=new List<decimal>();
            List<string> l4 = new List<string>();

            l = s.ConnectToDatabase1();
            //l4 = s.ConnectToDatabase4();
            l4.Add("doris carver");
            l4.Add("f chen");
            ViewBag.Tutors = l5;
            //model.StudentUserName = StudentName;
            ViewBag.list1 = l;
            ViewBag.list2 = l4;
            return View(model);
            

            //return RedirectToAction("Homepage", "Home");
        }
     

        public IActionResult StudentView(SlotsViewModel model, String StudentUserName)
        {
            /* if (Request.Cookies.TryGetValue(model.StudentUserName, out string myPropertyValue))
             {
                 model.StudentUserName = myPropertyValue;
             }
             else
             {
                 // Set a default value
                 model.StudentUserName = myPropertyValue;
             } */
            /*if (!string.IsNullOrEmpty(model.StudentUserName))
            {
                model.StudentUserName = StudentUserName;
                
                //model.StudentUserName = StudentUserName;
            }
            else
            {
                // Set a default value
                if (Request.Cookies.TryGetValue(model.StudentUserName, out string myPropertyValue))
                {
                    model.StudentUserName = myPropertyValue;
                }
            }*/
            model.StudentUserName = MyVariable;
            return View(model);
            //return RedirectToAction("Homepage", "Home");
        }
        public IActionResult ContactCoordinator(SlotsViewModel model)
        {
            model.StudentUserName = MyVariable;
            return View(model);
            //return RedirectToAction("Homepage", "Home");
        }
        public IActionResult TutorView(SlotsViewModel model)
        {
            //model = MyVariable;
            model.Name = MyVariable;
            return View(model);
            //return RedirectToAction("Homepage", "Home");
        }
        
        [HttpPost]
        public IActionResult ContactCoordinator(SlotsViewModel model, string Studentname)
        {
            model.StudentUserName = MyVariable;
            return View(model);
        }
        [HttpPost]
        public IActionResult RequestRecorded(SlotsViewModel model, string Studentname, string message)
        {
            model.StudentUserName = MyVariable;
            model.UserMessage = message;
            //model.StudentUserName = MyVariable;
            CoordinatorRequests cs = new CoordinatorRequests();
            cs.ConnectToDatabase(model);
            //Response.Cookies.Append(model.StudentUserName, Studentname);
            return View(model);
        }
        

            [HttpPost]
        public IActionResult DisplaySlots(DateTime date,string name, SlotsViewModel model, string Studentname)
        {
            model.StudentUserName = MyVariable;
            GetSlots s = new GetSlots();
            var timeSlots= s.ConnectToDatabase(date, name);
            model.Name = name;
            model.Date = date;
            model.Value = timeSlots;
            //model.StudentUserName = Studentname;
            // var timeSlots = GetTimeSlots(date);
            /*var model = new SlotsViewModel
            {
                Name = name,
                Date = date,
                Value = timeSlots
            }; */
            return View(model);
            //return View();
            // Do something with the date value
            //return View();
        }
        [HttpPost]
        public IActionResult CoordinatorDisplaySlots(DateTime date, string name, SlotsViewModel model, string Studentname)
        {
            model.StudentUserName = MyVariable;
            GetSlots s = new GetSlots();
            var timeSlots = s.ConnectToDatabase(date, name);
            model.Name = name;
            model.Date = date;
            model.Value = timeSlots;
            //model.StudentUserName = Studentname;
            // var timeSlots = GetTimeSlots(date);
            /*var model = new SlotsViewModel
            {
                Name = name,
                Date = date,
                Value = timeSlots
            }; */
            return View(model);
            //return View();
            // Do something with the date value
            //return View();
        }
        [HttpPost]
        public IActionResult BookTimeSlot(SlotsViewModel model, string timeSlot, string Studentname,DateTime date)
        {
            // Do something with the selected time slot value
            //TempData["MyModel"] = model;
            model.StudentUserName = MyVariable;
            SendRequestToTutor s = new SendRequestToTutor();
            s.ConnectToDatabase(model.Date, timeSlot, model.Name, Studentname);
            //model.StudentUserName = Studentname;
            // TempData["MyModel"] = JsonConvert.SerializeObject(model);
            //RedirectToAction("SendRequestsToTutor","Home");
            //string json = System.Text.Json.JsonSerializer.Serialize(model);
            //byte[] bytes = Encoding.UTF8.GetBytes(json);
            //HttpContext.Session.Set("MyModel", bytes);
            //return RedirectToAction("SendRequestsToTutor");
            return View();
        }
        [HttpPost]
        public IActionResult CoordinatorBookTimeSlot(SlotsViewModel model, string timeSlot, string Studentname, DateTime date)
        {
            // Do something with the selected time slot value
            //TempData["MyModel"] = model;
            model.StudentUserName = MyVariable;
            SendRequestToTutor s = new SendRequestToTutor();
            s.ConnectToDatabase(model.Date, timeSlot, model.Name, Studentname);
            //model.StudentUserName = Studentname;
            // TempData["MyModel"] = JsonConvert.SerializeObject(model);
            //RedirectToAction("SendRequestsToTutor","Home");
            //string json = System.Text.Json.JsonSerializer.Serialize(model);
            //byte[] bytes = Encoding.UTF8.GetBytes(json);
            //HttpContext.Session.Set("MyModel", bytes);
            //return RedirectToAction("SendRequestsToTutor");
            return View();
        }
        public IActionResult SendRequestsToTutor(SlotsViewModel model, string TutorName)
        {
            // Do something with the selected time slot value
            //TempData["PopupMessages"] = JsonConvert.DeserializeObject<List<PopupMessage>>(TempData["PopupMessages"].ToString());
            //var model = HttpContext.Session.Get;

            //var model = JsonConvert.DeserializeObject<SlotsViewModel>(TempData["MyModel"].ToString());
            //var model = TempData["MyModel"] as SlotsViewModel;
            model.studentrequestsDates = new List<string>();
            model.studentrequestsSlots = new List<string>();
            model.studentsUnameList = new List<string>();
            model.TutorUserName = new List<string>();

            NotificationDBConnection n = new NotificationDBConnection();
            List<string> dataList = new List<string>();
            List<string> dataList1 = new List<string>();
            TutorName = MyVariable;
            dataList = n.ConnectToDatabase(TutorName, dataList1);
            //dataList1 = n.ConnectToDatabase3(dataList);
            for (int i = 0; i < dataList1.Count; i = i + 4)
            {
                //model.studentrequestsDates[i]=dataList1[i];
                model.studentrequestsDates.Add(dataList1[i]);
                model.studentrequestsSlots.Add(dataList1[i + 1]);
                model.studentsUnameList.Add(dataList1[i + 2]);
                model.TutorUserName.Add(dataList1[i + 3]);
                // model.
            }
            // model.TutorUserName = TutorName;
            model.Requests = dataList;
            model.studentUsernameList = dataList1;
            return View(model);
        }
        [HttpPost]
        public IActionResult SetAvailability(DateTime date)
        {
            return View(date);
        }
        public IActionResult UpcomingAppointments(SlotsViewModel model, string TutorName)
        {
            CheckUpcomingAppointments c = new CheckUpcomingAppointments();
            List<string> strings = new List<string>();
            TutorName = MyVariable;
            strings = c.ConnectToDatabase(TutorName);
            model.Requests = strings;
            return View(model);
            //return RedirectToAction("Homepage", "Home");
        }
        [HttpPost]
        public IActionResult MyAppointments(string TutorName, SlotsViewModel model)
        {
            // Do something with the model property name
            // ...

            // Redirect back to the view or another action
            model.StudentUserName = MyVariable;
            StudentAppointmentStatus s = new StudentAppointmentStatus();
            List<string> l = new List<string>();
            List<string> l1 = new List<string>();
            l = s.ConnectToDatabase(MyVariable);
            l1 = s.ConnectToDatabase1(MyVariable);
            // model.studentsUnameList
            //model.StudentUserName = TutorName;
            model.Requests = l;
            model.TutorUserName = l1;
            // return RedirectToAction("Index");
            return View(model);
        }
        
            [HttpPost]
        public IActionResult TutorRating(string StudentName, SlotsViewModel model, string Name)
        {
            // Do something with the model property name
            // ...

            // Redirect back to the view or another action
            //StudentAppointmentStatus s = new StudentAppointmentStatus();
            //List<string> l = new List<string>();
            /* List<string> l1 = new List<string>();
             l = s.ConnectToDatabase(StudentName);
             l1 = s.ConnectToDatabase1(StudentName);
             model.Requests = l;
             model.TutorUserName = l1;
             // return RedirectToAction("Index"); */
            model.StudentUserName = MyVariable;
            model.Name = Name;
            return View(model);
        }

        public IActionResult SelectDate()
        {
            // Do something with the selected time slot value

            return View();
        }
        public IActionResult ViewStudentRequests(SlotsViewModel model)
        {
            // Do something with the selected time slot value
            CoordinatorRequests co = new CoordinatorRequests();
            List<string> msg=co.ConnectToDatabase();
            model.Requests=msg;
            return View(model);
        }
        public IActionResult ViewTutorRequests(SlotsViewModel model)
        {
            // Do something with the selected time slot value
            CoordinatorRequests co = new CoordinatorRequests();
            List<string> msg = co.ConnectToDatabase1();
            model.Requests = msg;
            return View(model);
        }
        public IActionResult ManageAppointments()
        {
            // Do something with the selected time slot value
            //CoordinatorRequests co = new CoordinatorRequests();
            //List<string> msg = co.ConnectToDatabase1();
            //model.Requests = msg;
           
            return View();
        }
        public IActionResult UpdateAppointment(SlotsViewModel model)
        {
            // Do something with the selected time slot value
            //CoordinatorRequests co = new CoordinatorRequests();
            //List<string> msg = co.ConnectToDatabase1();
            //model.Requests = msg;
            RegistrationValidation rs = new RegistrationValidation();
            List<string> ls = rs.ConnectToDatabase3();
            List<string> ls1 = rs.ConnectToDatabase2();
            model.studentUsernameList = ls1;
            model.TutorUserName = ls;

            return View(model);
        }
        /*
        public IActionResult deleteAppointment(SlotsViewModel model)
        {
            // Do something with the selected time slot value
            //CoordinatorRequests co = new CoordinatorRequests();
            //List<string> msg = co.ConnectToDatabase1();
            //model.Requests = msg;
            RegistrationValidation rs = new RegistrationValidation();
            List<string> ls = rs.ConnectToDatabase3();
            List<string> ls1 = rs.ConnectToDatabase2();
            model.studentUsernameList = ls1;
            model.TutorUserName = ls;

            return View(model);
        }
        */
        public IActionResult CreateAppointment(SlotsViewModel model)
        {
            // Do something with the selected time slot value
            //CoordinatorRequests co = new CoordinatorRequests();
            //List<string> msg = co.ConnectToDatabase1();
            //model.Requests = msg;
           // model.StudentList = new List<string>();
            //model.StudentList.Add("abanch1");
            //model.StudentList.Add("lkunku");
           RegistrationValidation rs = new RegistrationValidation();
           List<string> ls=rs.ConnectToDatabase2();
            model.studentUsernameList = ls;
            return View(model);
        }
        [HttpPost]
        public IActionResult CreateStudentAppointment(SlotsViewModel model)
        {
            // Do something with the selected time slot value
            //CoordinatorRequests co = new CoordinatorRequests();
            //List<string> msg = co.ConnectToDatabase1();
            //model.Requests = msg;
            // model.StudentList = new List<string>();
            //model.StudentList.Add("abanch1");
            //model.StudentList.Add("lkunku");
            RegistrationValidation rs = new RegistrationValidation();
            List<string> ls = rs.ConnectToDatabase2();
            model.studentUsernameList = ls;
            return View(model);
        }
        [HttpPost]
        public IActionResult CreateAppointmentForStudent(SlotsViewModel model)
        {
            // Do something with the selected time slot value
            //CoordinatorRequests co = new CoordinatorRequests();
            //List<string> msg = co.ConnectToDatabase1();
            //model.Requests = msg;
            // model.StudentList = new List<string>();
            //model.StudentList.Add("abanch1");
            //model.StudentList.Add("lkunku");
            MyVariable = model.studentUsernameList[0];
            return View(model);
        }
        [HttpPost]
        public IActionResult UpdateAppointmentForStudent(SlotsViewModel model)
        {
            // Do something with the selected time slot value
            //CoordinatorRequests co = new CoordinatorRequests();
            //List<string> msg = co.ConnectToDatabase1();
            //model.Requests = msg;
            // model.StudentList = new List<string>();
            //model.StudentList.Add("abanch1");
            //model.StudentList.Add("lkunku");
            CheckUpcomingAppointments c = new CheckUpcomingAppointments();
            List<string> strings = new List<string>();
            //TutorName = MyVariable;
            MyVariable = model.studentUsernameList[0];
            MyVariable1 = model.TutorUserName[0];
            strings = c.ConnectToDatabase1(model);
            model.Requests = strings;
            model.StudentUserName = model.studentUsernameList[0];
            model.Name = model.TutorUserName[0];
            //RedirectToAction("UpdateAppointment",model);
            return View(model);
        }

        [HttpPost]
        public IActionResult CreateStudentAppointment()
        {
            // Do something with the selected time slot value
            //CoordinatorRequests co = new CoordinatorRequests();
            //List<string> msg = co.ConnectToDatabase1();
            //model.Requests = msg;
            return View();
        }
        [HttpPost]
        public IActionResult BookAppointment(SlotsViewModel model, DateTime date)
        {
            // Do something with the selected time slot value
            //CoordinatorRequests co = new CoordinatorRequests();
            //List<string> msg = co.ConnectToDatabase1();
            //model.Requests = msg;
            MyVariable = model.StudentUserName;
            MyVariable1 = model.Name;
            return View(model);
        }
        /*
        [HttpPost]
        public IActionResult CancelAppointment(SlotsViewModel model, DateTime date)
        {
            // Do something with the selected time slot value
            //CoordinatorRequests co = new CoordinatorRequests();
            //List<string> msg = co.ConnectToDatabase1();
            //model.Requests = msg;
            MyVariable = model.StudentUserName;
            MyVariable1 = model.Name;
            return View(model);
        }
        */
        [HttpPost]
        public IActionResult CancelAppointment(SlotsViewModel model)
        {
            // Do something with the selected time slot value
            //CoordinatorRequests co = new CoordinatorRequests();
            //List<string> msg = co.ConnectToDatabase1();
            //model.Requests = msg;
            MyVariable = model.StudentUserName;
            MyVariable1 = model.Name;
            GetSlots s = new GetSlots();
            s.ConnectToDatabase1(model);
            //var timeSlots = s.ConnectToDatabase(model.Date, MyVariable1);
            //model.Name = name;
            //model.Date = date;
            //model.Value = timeSlots;
            //model.StudentUserName = Studentname;
            // var timeSlots = GetTimeSlots(date);
            /*var model = new SlotsViewModel
            {
                Name = name,
                Date = date,
                Value = timeSlots
            }; */
            //return View(model);
            return View(model);
        }
        public IActionResult deleteAppointment(SlotsViewModel model)
        {
            // Do something with the selected time slot value
            //CoordinatorRequests co = new CoordinatorRequests();
            //List<string> msg = co.ConnectToDatabase1();
            //model.Requests = msg;
            RegistrationValidation rs = new RegistrationValidation();
            List<string> ls = rs.ConnectToDatabase3();
            List<string> ls1 = rs.ConnectToDatabase2();
            model.studentUsernameList = ls1;
            model.TutorUserName = ls;

            return View(model);
        }
        [HttpPost]
        public IActionResult DeleteSelectedAppointment(SlotsViewModel model)
        {
            // Do something with the selected time slot value
            //CoordinatorRequests co = new CoordinatorRequests();
            //List<string> msg = co.ConnectToDatabase1();
            //model.Requests = msg;
            // model.StudentList = new List<string>();
            //model.StudentList.Add("abanch1");
            //model.StudentList.Add("lkunku");
            CheckUpcomingAppointments c = new CheckUpcomingAppointments();
            List<string> strings = new List<string>();
            //TutorName = MyVariable;
            MyVariable = model.studentUsernameList[0];
            MyVariable1 = model.TutorUserName[0];
            strings = c.ConnectToDatabase1(model);
            model.Requests = strings;
            model.StudentUserName = model.studentUsernameList[0];
            model.Name = model.TutorUserName[0];
            //RedirectToAction("UpdateAppointment",model);
            return View(model);
        }
        /*[HttpPost]
        public IActionResult DeleteSelectedAppointment(SlotsViewModel model, DateTime date)
        {
            // Do something with the selected time slot value
            //CoordinatorRequests co = new CoordinatorRequests();
            //List<string> msg = co.ConnectToDatabase1();
            //model.Requests = msg;
            MyVariable = model.StudentUserName;
            MyVariable1 = model.Name;
            return View(model);
        } */
        [HttpPost]
        public IActionResult Coordinatorselectdate(SlotsViewModel model)
        {
            // Do something with the selected time slot value
            //CoordinatorRequests co = new CoordinatorRequests();
            //List<string> msg = co.ConnectToDatabase1();
            //model.Requests = msg;
            MyVariable = model.StudentUserName;
            MyVariable1 = model.Name;
            GetSlots s = new GetSlots();
            s.ConnectToDatabase1(model);
            var timeSlots = s.ConnectToDatabase(model.Date, MyVariable1);
            //model.Name = name;
            //model.Date = date;
            model.Value = timeSlots;
            //model.StudentUserName = Studentname;
            // var timeSlots = GetTimeSlots(date);
            /*var model = new SlotsViewModel
            {
                Name = name,
                Date = date,
                Value = timeSlots
            }; */
            //return View(model);
            return View(model);
        }
        [HttpPost]
        public IActionResult EditProfile(SlotsViewModel model)
        {
            model.Name = MyVariable;
            return View(model);
        }
        [HttpPost]
        public IActionResult EditTutorProfile(SlotsViewModel model)
        {
            model.Name = MyVariable;
            return View(model);
        }

        [HttpPost]
        public IActionResult SaveProfileInfo(SlotsViewModel model)
        {
            model.Name = MyVariable;
            //MyVariable = model.Name;
            //MyVariable1 = model.Name;
            StudentProfile p = new StudentProfile();
            p.ConnectToDatabase1(MyVariable,model);
            List<string> ls=p.ConnectToDatabase(MyVariable);
            model.StudentInfo = ls;

            return View(model);
        }
        [HttpPost]
		public IActionResult StudentProfile(SlotsViewModel model)
		{
			// Do something with the selected time slot value
			//CoordinatorRequests co = new CoordinatorRequests();
			//List<string> msg = co.ConnectToDatabase1();
			//model.Requests = msg;
			MyVariable = model.Name;
			//MyVariable1 = model.Name;
            StudentProfile p=new StudentProfile();
            List<string> ls=p.ConnectToDatabase(MyVariable);
            model.StudentInfo = ls;
			
			//model.StudentUserName = Studentname;
			// var timeSlots = GetTimeSlots(date);
			/*var model = new SlotsViewModel
            {
                Name = name,
                Date = date,
                Value = timeSlots
            }; */
			//return View(model);
			return View(model);
		}
        [HttpPost]
        public IActionResult TutorProfile(SlotsViewModel model)
        {
            // Do something with the selected time slot value
            //CoordinatorRequests co = new CoordinatorRequests();
            //List<string> msg = co.ConnectToDatabase1();
            //model.Requests = msg;
            MyVariable = model.Name;
            //MyVariable1 = model.Name;
            StudentProfile p = new StudentProfile();
            List<string> ls = p.ConnectToDatabase(MyVariable);
            model.StudentInfo = ls;

            //model.StudentUserName = Studentname;
            // var timeSlots = GetTimeSlots(date);
            /*var model = new SlotsViewModel
            {
                Name = name,
                Date = date,
                Value = timeSlots
            }; */
            //return View(model);
            return View(model);
        }


        public IActionResult CoordinatorView()
        {
            // Do something with the selected time slot value

            return View();
        }
        public IActionResult SubmitRating(decimal rating, string TutorName, SlotsViewModel model)
        {
            // Do something with the selected time slot value
            SubmitRating s = new SubmitRating();
           s.ConnectToDatabase(TutorName, rating);
           // model.rating = UpdatedRating;
            return View(model);
        }
        public IActionResult TutorResponse()
        {
            // Do something with the selected time slot value

            return View();
        }

        public IActionResult RequestStatus(SlotsViewModel model, List<string> RequestStatus)
        {
            //if (ModelState.IsValid)
            //{
            //RegistrationValidation rv = new RegistrationValidation();
            //rv.ConnectToDatabase(model);
            // Do something with the model data
            // return RedirectToAction("Homepage", "Home");
            //var items = JsonSerializer.Deserialize<string[]>(model.RequestId[0].ToString());
            RequestStatusSubmission rs = new RequestStatusSubmission();
                rs.ConnectToDatabase(model);

            //}
            //else
            //{
              //  ModelState.AddModelError("", "No match");
            //}
            //return View();
            return RedirectToAction("TutorResponse", "Home");
        }
        public IActionResult MarkMessage(SlotsViewModel model, List<string> RequestStatus)
        {
            //if (ModelState.IsValid)
            //{
            //RegistrationValidation rv = new RegistrationValidation();
            //rv.ConnectToDatabase(model);
            // Do something with the model data
            // return RedirectToAction("Homepage", "Home");
            //var items = JsonSerializer.Deserialize<string[]>(model.RequestId[0].ToString());
            for (int i = 0; i < model.Requests.Count; i++)
            {
                model.Requests[i] = model.Requests[i].Substring(model.Requests[i].IndexOf("Message: ") + 9);
            }
            CoordinatorRequests rs = new CoordinatorRequests();
            rs.ConnectToDatabase3(model);

            //}
            //else
            //{
            //  ModelState.AddModelError("", "No match");
            //}
            //return View();
            return RedirectToAction("CoordinatorView", "Home");
        }
        public IActionResult NotificationMethod()
        { List<string> Id =new List<string>();
        // string connectionString = "Data Source=DESKTOP-AGRLESG\SQLEXPRESS;Initial Catalog=UniversityTutoringWebsiteDatabase;Integrated Security=SSPI;";
        NotificationDBConnection nm = new NotificationDBConnection();
            List<string> dataList = new List<string>();
          //  dataList = nm.ConnectToDatabase();
            
        //ViewBag.Message = "Hello, World!";
        //return RedirectToAction("Homepage", "Home");
        Homepagemodel model = new Homepagemodel();
            int j=0;
            for (int i = 0; i < dataList.Count; i=i+4)
            {
                //model.message = "hello";
                //model.StudentId.Insert(j,) = "random";
                //Id[0] = "hello";
                model.RequestId.Insert(j, dataList[i]);
                //model.RequestId[j] = dataList[i];
                model.StudentId.Insert(j, dataList[i + 1]);
                model.RequestedSlot.Insert(j ,dataList[i + 2]);
                model.Requestmessage.Insert(j, dataList[i+3]);
                j++;
            }
            //model.Requestmessage = dataList;
            //model.
            //TempData["MyModel"] = model;
            //return RedirectToAction("Action2");
            //var model = new Homepagemodel();

            return View(model);
        }
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if (username.Equals("admin"))
            {
                MyVariable = username;
                return RedirectToAction("CoordinatorView", "Home");
            }
            else
            {
                LoginValidation lv = new LoginValidation();
                string usertype = lv.ConnectToDatabase(username, password);
                SlotsViewModel model = new SlotsViewModel();
                model.StudentUserName = username;
                model.Name = username;

                if (!usertype.Equals(""))
                {
                    // Redirect to the home page or a success page
                    if (usertype.Equals("Student"))
                    {
                        //Response.Cookies.Append(model.StudentUserName, username);
                        MyVariable = username;
                        return RedirectToAction("StudentView", "Home", model);
                    }
                    else
                    {
                        MyVariable = username;
                        return RedirectToAction("TutorView", "Home", model);
                    }

                    // return count;
                }
                else
                {
                    // Add an error message to the model state
                    //ModelState.AddModelError("", "Invalid username or password.");
                    //TempData["ErrorMessage"] = "Invalid username or password.";

                    // Return to the Create action method
                    //return RedirectToAction("Create");
                    // return RedirectToAction("Homepage", "Home");
                    //return View();
                    // return 0;
                    ViewBag.ErrorMessage = "Invalid username or password.";
                    return View();
                }

                // return View();
            }
        }
      
        public ActionResult Registration(RegisterViewModel model)
        {
            if (model == null || (model.Username == default && model.Password == default && model.ConfirmPassword == default))
            {
                return View();
            }
            if (ModelState.IsValid)
            {
                RegistrationValidation rv = new RegistrationValidation();
                rv.ConnectToDatabase(model);
                // Do something with the model data
                //TempData["MyModel"] = model;
                return RedirectToAction("HomePage", "Home");
            }
            else
            {
                ModelState.AddModelError("", "No match");
            }
            
            return View();
        }
        
        public IActionResult Calender()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult SaveSelectedSlots(DateTime date, string[] timeSlots, string name)
        {
            // Process the selected time slots for the specified date, such as saving them to a database.
            SaveSelectedSlots s=new SaveSelectedSlots();
            name = MyVariable;
            s.ConnectToDatabase(date,timeSlots,name);
            return RedirectToAction("SlotSaved");
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult SlotSaved()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

    
}
