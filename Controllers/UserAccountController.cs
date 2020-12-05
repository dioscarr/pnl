using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using pnl.Data;
using pnl.Data.Models;
using pnl.Models;

namespace pnl.Controllers
{
    [Authorize]
    public class UserAccountController : Controller
    {
        private readonly ApplicationDbContext _db;
        public UserAccountController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            UserAccountViewModel uavm = new UserAccountViewModel();
            uavm.Init(_db);
            var usrId = User.Claims.First().Value;
            if (_db.Person.Any(c => c.UserId == usrId))
            {
                uavm.GetCurrentUserInfo(usrId);
                return View(uavm);
            }
            else
            {
                return View(uavm);
            }
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

            //if (_db.Address.Any(c => c.PersonID == model.CurrentUser.id) && model.Address != null)
            //{
            //    _db.Update(model.Address);
            //    _db.SaveChanges();
            //}
            //else
            //{
            //    model.Address.PersonID = model.CurrentUser.id;
            //    _db.Address.Add(model.Address);
            //    _db.SaveChanges();
            //}
            return RedirectToAction(nameof(Index));
        }
    }
}
