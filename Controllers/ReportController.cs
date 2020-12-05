using Castle.Core.Logging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.Extensions.Logging;
using pnl.Data;
using pnl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pnl.Controllers
{
    public class ReportController : Controller
    {
        private readonly ILogger<ReportController> _logger;
        private readonly ApplicationDbContext _db;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IWebHostEnvironment _env;
        HostingEnvironment _host;


        public ReportController(ILogger<ReportController> logger, ApplicationDbContext db,
            IHttpContextAccessor httpContextAccessor, IWebHostEnvironment env)
        {
            _logger = logger;
            _db = db;
            _httpContextAccessor = httpContextAccessor;
            _env = env;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetPdf(int taxFormId)
        {
            ReportData r = new ReportData(_db, _httpContextAccessor, _env);
            return File(r.GetPdfReport(taxFormId), "application/pdf");
        }
    }
}
