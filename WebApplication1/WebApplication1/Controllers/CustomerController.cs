using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;
using System.Data.Entity;
using System.Diagnostics;

namespace WebApplication1.Controllers
{
    public class CustomerController : Controller
    {


        public AppDbContext _dbContext;

        public CustomerController()
        {
            _dbContext = new AppDbContext("Server=tcp:abdullahzizo.database.windows.net,1433;Initial Catalog=Store;Persist Security Info=False;User ID=abdullah;Password={admin123;};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }


        public Boolean check_username(string name)
        {
            bool check = false;

            var viewModel = new CustomerViewModel();
            viewModel.customers = _dbContext.customers.ToList();

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

        public IActionResult Display()
        {
            var customers = _dbContext.customers.ToList();

            return View(customers);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Customer customer)
        {
         
                if (ModelState.IsValid)
                {
                    _dbContext.customers.Add(customer);
                    _dbContext.SaveChanges();
                    return RedirectToAction("Display");
            }

            
            return View(customer);
        }

        public ActionResult Edit(int? id)
        {
            Trace.WriteLine("GET /Todos/Edit/" + id);
            
            Customer customer = _dbContext.customers.Find(id);

            return View(customer);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Entry(customer).State = EntityState.Modified;
                _dbContext.SaveChanges();
                return RedirectToAction("Display");
            }
            return View(customer);
        }

      
        public ActionResult Delete(int? id)
        {
            Customer customer = _dbContext.customers.Find(id);

            return View(customer);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            Customer customer = _dbContext.customers.Find(id);
            _dbContext.customers.Remove(customer);
            _dbContext.SaveChanges();

            return RedirectToAction("Display");
        }  
       
    }
}
