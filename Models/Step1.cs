using Microsoft.EntityFrameworkCore;
using pnl.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pnl.Models
{
    public class Step1
    {
        public List<Person> CurrentUserInfo { get; internal set; }
    }
}
