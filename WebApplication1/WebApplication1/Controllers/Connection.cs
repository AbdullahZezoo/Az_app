using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;

namespace WebApplication1.Controllers
{
    public class Connection : Controller
    {
        public AppDbContext _dbContext;
       
        public Connection()
        {
            _dbContext = new AppDbContext("Server=tcp:abdullahzezo.database.windows.net,1433;Initial Catalog=Store;Persist Security Info=False;User ID=abdullahzezo;Password={abdullah123;};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }

    }

}
