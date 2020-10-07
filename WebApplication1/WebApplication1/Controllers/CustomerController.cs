using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CustomerController : Controller
    {


        Connection co = new Connection();

        public Boolean check_username(string name)
        {
            bool check = false;

            var viewModel = new CustomerViewModel();
            viewModel.customers = co._dbContext.customers.ToList();

            foreach(var customer in viewModel.customers)
            {
                if (customer.Name.Equals(name))
                {
                    check = false;
                    break;
                }
                else
                    check = true;
            }
            return check;
        }

        public IActionResult Create()
        {
            var customer = new Customer();
            customer.Name = Request.Form["fullName"];
            customer.address = Request.Form["address"];
            customer.age = Convert.ToInt32(Request.Form["age"]);
            customer.gender = Request.Form["gender"];

            if (check_username(customer.Name))
            {
                if (ModelState.IsValid)
                {
                    co._dbContext.customers.Add(customer);
                    co._dbContext.SaveChanges();
                }

            }
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult Delete()
        {
            var customer = new Customer();
            customer.Name = Request.Form["Name"];

            

            return View();
        }
    }
}
