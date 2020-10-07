using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Customer
    {

        [Key]
        public int Id{ get; set; }

        public string Name { get; set; }

        public string address { get; set; }

        public int age{ get; set; }

        public string gender { get; set; }

    }
}
