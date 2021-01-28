using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using pnl.Areas.PnlAccess.Models;
using pnl.Data;
using pnl.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pnl.Areas.PnlAccess.Controllers
{
    [Area("pnlaccess")]
    public class NotificationCenterController : Controller
    {
        private readonly ILogger<NotificationCenterController> _logger;
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public NotificationCenterController(ILogger<NotificationCenterController> logger, ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _db = db;
            _userManager = userManager;
        }
        public IActionResult Index(int id)
        {
            NotificationCenterVM ncvm = new NotificationCenterVM();
            ncvm.taxForm = _db.TaxForms.First(c => c.ID == id);
            ncvm.Notification = new Notifications();
            ncvm.Notification.CreatedOn = DateTime.Now;
            ncvm.Notification.UpdatedOn = DateTime.Now;
            ncvm.Notification.UserId = ncvm.taxForm.UserID;
            ncvm.Notification.SentByAdmin = true;
            ncvm.Notification.isDeleted = false;
            ncvm.Notification.Read = false;
            ncvm.ProfilePicture = _db.Users.First(c => c.Id == ncvm.taxForm.UserID).ProfilePicture;


            ncvm.Notifications = _db.Notifications.Where(c => c.UserId == ncvm.taxForm.UserID).ToList();

            return View(ncvm);
        }
       
        [HttpPost]
        public IActionResult Index(NotificationCenterVM model)
        {
            try
            {
               var t =  _db.TaxForms.First(c => c.ID == model.taxForm.ID);
                model.Notification.CreatedOn = DateTime.Now;
                model.Notification.UpdatedOn = DateTime.Now;
                model.Notification.UserId = model.taxForm.UserID;
                model.Notification.SentByAdmin = true;
                model.Notification.isDeleted = false;
                model.Notification.Read = false;
                model.Notification.TaxFormId = model.taxForm.ID;
                t.Notifications.Add(model.Notification);
                _db.Update(t);
                _db.SaveChanges();
                return RedirectToAction("Index", "Home", new { area = "pnlaccess" });
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public IActionResult Remove(int id)
        {
            try
            {
                _db.Remove(_db.Notifications.First(c => c.id == id));
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                throw;
            }
        
        }
        public IActionResult Edit(int id)
        {
            try
            {
                NotificationCenterVM ncvm = new NotificationCenterVM();
                var notfi = _db.Notifications.First(c => c.id == id);
                ncvm.taxForm = _db.TaxForms.First(c => c.ID == notfi.TaxFormId);
                ncvm.Notification = notfi;
                ncvm.Notifications = _db.Notifications.Where(c => c.UserId == ncvm.taxForm.UserID).ToList();

                return View("Index", ncvm );                
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
