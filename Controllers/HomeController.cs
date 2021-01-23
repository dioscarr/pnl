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
                    return RedirectToAction("CompleteRegistration");
                }
                catch (Exception)
                {

                    throw;
                }
            }

            ViewData.Add("Title","dashbaord");
            dashboard d = new dashboard(_db);
            d.init(User.Claims.First().Value);

            if (d.CurrentUser == null)
            {
                return RedirectToAction("CompleteRegistration");
            }
            return View(d);
        }
        public IActionResult CompleteRegistration()
        {
            var registration = new UserAccountViewModel();
            registration.Init(_db);
            return View(registration);
        }
        [HttpPost]

        public IActionResult Update(UserAccountViewModel model)
        {
            var usrId = User.Claims.First().Value;
            if (_db.Person.Any(c => c.UserId == usrId))
            {
                model.Address.PersonID = model.CurrentUser.id;
                model.CurrentUser.Address = model.Address;
                _db.Update(model.CurrentUser);
                _db.SaveChanges();
            }
            else
            {
                model.CurrentUser.UserId = usrId;
                model.CurrentUser.Address = model.Address;
                _db.Person.Add(model.CurrentUser);
                _db.SaveChanges();
            }

            return RedirectToAction("Index");
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
