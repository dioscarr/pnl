using pnl.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pnl.Areas.PnlAccess.Models
{
    public class NotificationCenterVM
    {
        public NotificationCenterVM()
        {
            Notification = new Notifications();
            taxForm = new TaxForm();
            Notifications = new List<Notifications>();
        }

        public Notifications Notification { get; set; }
        public TaxForm taxForm { get; set; }
        public List<Notifications> Notifications { get; set; }
        public byte[] ProfilePicture { get; set; }
    }
}
