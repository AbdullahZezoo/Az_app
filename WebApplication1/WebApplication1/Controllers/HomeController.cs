using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication1.Models;
using System.Collections;
using WebApplication1.Data;
using System.Data.Entity;


namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {

        public AppDbContext _dbContext;

        public HomeController()
        {
            _dbContext = new AppDbContext("Server=tcp:abdullahzizo.database.windows.net,1433;Initial Catalog=Store;Persist Security Info=False;User ID=abdullah;Password={admin123;};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }


        public Boolean check_user(User user)
        {
            bool check = false;


            var users = _dbContext.users.ToList();
            foreach (var _user in users)
            {
                if (_user != null && user != null)
                {

                    if (_user.u_username.Equals(user.u_username) && _user.u_password.Equals(user.u_password))
                    {
                        check = true;
                        break;
                    }
                }
            }

            return check;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Welcome()
        {

            var viewModel = new UserViewModel();
            viewModel.users = _dbContext.users.ToList();

            return View(viewModel);
        }

        


        public IActionResult LoginPage()
        {
            return View();
        }

        public Boolean check_username(string username)
        {
            bool check = true;
            var users = _dbContext.users.ToList();
            foreach (var user in users)
            {
                if (user != null)
                {
                    if (user.u_username.Equals(username))
                    {
                        check = false;

                    }
                }

            }
            return check;
        }

        
        public IActionResult Login()
        {
            var user = new User();
            user.u_username = Request.Form["username"];
            user.u_password = Request.Form["password"];

            var viewModel = new UserViewModel();
            viewModel.users = _dbContext.users.ToList();

            string message = "";

            if (check_user(user))
            {
                message = "Login Successfully.";
                return RedirectToAction("Display", "Customer");
            }
            else
                message = "Login failed.";

            
            ViewBag.sUsername = user.u_username;
            ViewBag.sPassword = user.u_password;
            ViewBag.sName = user.u_name;

            ViewData["message"] = message;
            return View();

        }
        
        public IActionResult RegisterPage()
        {
            return View();
        }

        public IActionResult Register()
        {
            var user = new User();
            user.u_name = Request.Form["name"];
            user.u_username = Request.Form["username"];
            user.u_password = Request.Form["password"];


            ViewBag.sName = user.u_name;

                if (ModelState.IsValid)
                {
                    _dbContext.users.Add(user);
                    _dbContext.SaveChanges();
                    ViewBag.message = "Register Successfully, You Can Login NOW.";
                }
                else
                {
                    ViewBag.message = "Register Failed, Plese Try Again.";
                }
            


            return View();
        }

      
    }
}
