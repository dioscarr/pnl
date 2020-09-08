using Microsoft.EntityFrameworkCore;
using pnl.Data;
using pnl.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pnl.Models
{
    public class UserAccountViewModel : IUserAccount
    {
        private ApplicationDbContext _db;

        public Person CurrentUser { get; set; }
        public Address Address { get; set; }
        public void Init(ApplicationDbContext db)
        {
            _db = db;
            CurrentUser = new Person();
            Address = new Address();
        }
       
        public void GetCurrentUserInfo(string userID)
        {
            CurrentUser = (_db.Person.Any(c => c.UserId == userID)) ? _db.Person.Where(c => c.UserId == userID).First() : new Person();
            Address =  (CurrentUser.Address!=null) ? CurrentUser.Address.First() : new Address();
        }        

    }
}
