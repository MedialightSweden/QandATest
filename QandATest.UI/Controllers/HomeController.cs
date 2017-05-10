using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QandATest.DomainEntities;
using QandATest.DataAccess;

namespace QandATest.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly MainDbContext _context;

        public HomeController(MainDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SearchResult(Advertisement ad)
        {
            var model = _context.Advertisement.ToList();
            return PartialView("_AdvertisementList", model);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
