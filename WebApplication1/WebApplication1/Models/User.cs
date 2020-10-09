using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string u_username { get; set; }

        public string u_password { get; set; }

        public string u_name { get; set; }


    }
}
