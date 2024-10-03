using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Request.Controllers;
using Request.Models;

namespace Request.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }

        private UserRepository userRepository = new UserRepository();

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User model)
        {
            if (ModelState.IsValid)
            {

                if (!userRepository.IsUsernameAvailable(model.Username))
                {
                    ModelState.AddModelError("Username", "Username is already taken.");
                    return View(model);
                }

                model.Password = BCrypt.Net.BCrypt.HashPassword(model.Password);

                bool isRegistered = userRepository.Register(model);
                if (isRegistered)
                {
                    return RedirectToAction("Login");
                }
            }
            return View(model);
        }

        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            if (ModelState.IsValid)
            {
                User user = userRepository.Login(username, password);

                if (user != null)
                {
                    Session["UserId"] = user.UserId;
                    Session["Username"] = user.Username;
                    Session["Role"] = user.Role;


                    if (user.Role == "Admin")
                    {
                        return RedirectToAction("About", "Home");
                    }
                    else if (user.Role == "Requestor")
                    {
                        return RedirectToAction("Contact", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Invalid login attempt.");
                }
            }
            return View();
        }


        // You might also want to create a Logout action
        public ActionResult Logout()
        {
            // Clear session or authentication
            return RedirectToAction("Login", "Account");
        }



        //LOGIN------------------------------------------------------------------>

        //[HttpPost]
        //public ActionResult Login(string username, string password)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        User user = userRepository.Login(username, password);

        //        if (user != null)
        //        {
        //            // Store necessary session data
        //            Session["UserId"] = user.UserId;
        //            Session["Username"] = user.Username;
        //            Session["Role"] = user.Role;

        //            // Store the full name and username in TempData
        //            TempData["FullName"] = $"{user.FirstName} {user.LastName}"; // Adjust as needed
        //            TempData["Username"] = user.Username;

        //            // Redirect based on role
        //            if (user.Role == "Admin")
        //            {
        //                return RedirectToAction("About", "Home");
        //            }
        //            else if (user.Role == "Requestor")
        //            {
        //                return RedirectToAction("Contact", "Home");
        //            }
        //        }
        //        else
        //        {
        //            // Invalid username or password
        //            ModelState.AddModelError("", "Invalid username or password.");  
        //        }
        //    }
        //    return View();
        //}



        //GET FULLNAME----------------------------------------------------------->
        public string GetFullName(string userId)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == userId);
            if (user != null)
            {
                return $"{user.FirstName} {user.LastName}";
            }
            else
            {
                // Log or handle the case where the user is not found
                Console.WriteLine($"User not found for ID: {userId}"); // Or use a logging framework
                return "User not found";
            }
        }
    }
}