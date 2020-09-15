using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using pnl.Data;
using pnl.Models;

namespace pnl.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            if (!_db.Person.Any(c => c.UserId == User.Claims.First().Value))
            {
                try
                {

                    var person = new Data.Models.Person()
                    {
                        UserId = User.Claims.First().Value,
                        FirstName = "Dioscar",
                        LastName = "Rodriguez",
                        Birthday = DateTime.Parse("12/29/1985"),
                        Email = User.Identity.Name,
                        Phone = "3472009415",
                        SSN = "888888888",
                        Occupation = "Software Engineer",
                        MiddleName = "D",
                        Address = new Data.Models.Address() { 
                            Address1 = "935 York street",
                            Address2 = "2nd fl",
                            City = "East Rutherford",
                            State = "NJ",
                            Zip = "07073"
                        }
                    };

                    _db.Add(person);
                    _db.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
