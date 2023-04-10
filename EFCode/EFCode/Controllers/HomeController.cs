using EFCode.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EFCode.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpPost]
        public IActionResult Login(string username, string password)
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
                    return RedirectToAction("StudentView", "Home", model);
                }
                else
                {
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
        [HttpPost]
        public IActionResult SetAvailability(DateTime date)
        {
            return View(date);
        }
        [HttpPost]
        public IActionResult SaveSelectedSlots(DateTime date, string[] timeSlots, string name)
        {
            // Process the selected time slots for the specified date, such as saving them to a database.
            SaveSelectedSlots s = new SaveSelectedSlots();
            s.ConnectToDatabase(date, timeSlots, name);
            return RedirectToAction("SlotSaved");
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
    }
}