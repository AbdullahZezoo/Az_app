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

        Connection co = new Connection();
        public Boolean check_user(User user)
        {
            bool check = false;

            var viewModel = new UserViewModel();
            viewModel.users = co._dbContext.users.ToList();

            foreach (var _user in viewModel.users)
            {
                if(_user.u_username.Equals(user.u_username) && _user.u_password.Equals(user.u_password))
                {
                    check = true;
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
            viewModel.users = co._dbContext.users.ToList();

            return View(viewModel);
        }

        


        public IActionResult LoginPage()
        {
            return View();
        }

        public Boolean check_username(string username)
        {
            bool check = false;
            var viewModel = new UserViewModel();
            viewModel.users = co._dbContext.users.ToList();
            foreach (var user in viewModel.users)
            {
                if (user.u_username.Equals(username))
                {
                    check = false;
                }
                else
                    check = false;
            }
            return check;
        }

        
        public IActionResult Login()
        {
            var user = new User();
            user.u_username = Request.Form["username"];
            user.u_password = Request.Form["password"];

            var viewModel = new UserViewModel();
            viewModel.users = co._dbContext.users.ToList();

            string message = "";

            if (check_user(user))
                message = "Login Successfully.";
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
            user.u_name = Request.Form["fullName"];
            user.u_username = Request.Form["username"];
            user.u_password = Request.Form["password"];

            if (check_username(user.u_username))
            {
                if (ModelState.IsValid)
                {
                    co._dbContext.users.Add(user);
                    co._dbContext.SaveChanges();
                }

            }
            
            ViewBag.sName = user.u_name;
            ViewBag.sUsername = user.u_username;
            ViewBag.sPassword = user.u_password;

            return View();
        }

      
    }
}
