using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Models
{
    public class CustomerViewModel
    {

        public CustomerViewModel()
        {
            customers = new List<Customer>();
        }

        public List<Customer> customers = new List<Customer>();
    }
}
