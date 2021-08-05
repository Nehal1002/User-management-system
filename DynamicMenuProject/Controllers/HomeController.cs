using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DynamicMenuProject.Models;
using Microsoft.AspNetCore.Authorization;
using DynamicMenuProject.Data;

namespace DynamicMenuProject.Controllers
{
    //[AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [AllowAnonymous]
        public IActionResult Pages(string Id)
        {
            CMSItems mvm = new CMSItems();
            var page = (_context.CMSItems.Where(p => p.PageUrl == Id).ToList());
            foreach (var item in page)
            {
                mvm.PageName = item.PageName;
                mvm.Description = item.Description;
                mvm.BannerImage = item.BannerImage;
            }
            return View(mvm);
        }

        [AllowAnonymous]
        public JsonResult Country()
        {
            var coun = _context.Countries.
                Select(x => new { value = x.CountryId, text = x.CountryName }).ToList();
            return Json(coun);
        }


        [AllowAnonymous]
        public JsonResult GetStatesByCountryId(int CountryId)
        {
            var sta = _context.States.Where(x => x.CountryId == CountryId).
                Select(x => new { value = x.StateId, text = x.StateName }).ToList();
            return Json(sta);
        }

        [AllowAnonymous]
        public JsonResult GetCitiesByStateId(int StateId)
        {
            var city = _context.Cities.Where(x => x.StateId == StateId).
                Select(x => new { value = x.CityId, text = x.CityName }).ToList();
            return Json(city);
        }
    }
}
