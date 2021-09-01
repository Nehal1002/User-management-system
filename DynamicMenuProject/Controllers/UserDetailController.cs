using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DynamicMenuProject.Data;
using DynamicMenuProject.Models;
using DynamicMenuProject.Security;
using DynamicMenuProject.View_Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;

namespace DynamicMenuProject.Controllers
{
    public class UserDetailController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public UserDetailController(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult GetUser(Guid UserId)
        {
            AVViewModel viewModel = new AVViewModel();
            var user = _context.Users.Where(x => x.Id == UserId.ToString()).FirstOrDefault();
            if (user != null)
            {
                //viewModel.Id = user.Id.to;
                viewModel.UserName = user.UserName;
                viewModel.FirstName = user.FirstName;
                viewModel.LastName = user.LastName;
                viewModel.Email = user.Email;
                viewModel.Address1 = user.Address1;
            }

            var UserList = (from users in _context.Users
                            select new SelectListItem
                            {
                                Value = users.Id,
                                Text = users.UserName
                            }).ToList();
            ViewBag.UserList = UserList;
            return View(viewModel);
        }

        [HttpPost]
        public JsonResult GetUser(AVViewModel model)
        {
            var crypt = model.UserIdNew + "/" + model.code;
            Encryption encryption = new Encryption();
            string UniqueKey = _configuration["Encryption:UniqueKey"];
            var quc = encryption.EncryptString(crypt, UniqueKey);
            SurveyUrl et = new SurveyUrl();
            et.Url = crypt;
            et.EncryptUrl = quc;
            et.StartDate = model.StartDate;
            et.EndDate = model.EndDate;
            _context.SurveyUrl.Add(et);
            _context.SaveChanges();
            return Json("Saved Successfully");
        }

        public IActionResult Decrypt()
        {
            var dec = _context.SurveyUrl.OrderByDescending(x => x.Id).FirstOrDefault().EncryptUrl;
            Encryption encryption = new Encryption();
            string UniqueKey = _configuration["Encryption:UniqueKey"];
            var decryptURL = encryption.DecryptString(dec, UniqueKey);
            var userId = decryptURL.Split('/')[0];
            //if (userId != null && userId == decryptURL)
            if(_context.Users.Where(a=>a.Id==userId).Count()>0)
            {
                return Json("Decrypt Successfull.");
            }
            else
            {
                return Json("Credential mismatch");
            }

        }

        public IActionResult Desc()
        {
            var sentDate = _context.SurveyUrl.ToList();

            return View();
        }
    }
}