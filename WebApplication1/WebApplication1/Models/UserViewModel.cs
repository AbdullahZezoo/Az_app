using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class UserViewModel
    {

        public UserViewModel()
        {
            users = new List<User>();
        }

        public List<User> users = new List<User>();


    }
}
