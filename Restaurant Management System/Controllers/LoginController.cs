using Restaurant_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restaurant_Management_System.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Authorize(Restaurant_Management_System.Models.User userModel)
        {
            using (RestaurantManagementSystemEntities db = new RestaurantManagementSystemEntities() )
            {
                var userDetails = db.Users.Where(x => x.username == userModel.username && x.password == userModel.password).FirstOrDefault();
                if (userDetails == null)
                {
                    userModel.LoginErrorMessage = "Wrong username or password";
                    return View("Index", userModel);
                }
                else
                {
                    Session["id"] = userDetails.id;
                    return RedirectToAction("Index", "Home");
                }
            }
        }
    }
}