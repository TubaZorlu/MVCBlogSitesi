using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcProjeKampi.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly IAdminService _adminService;
        private readonly IWriterService _writerService;
        private readonly IWriterloginService _writerloginService;


        public LoginController(IAdminService adminService, IWriterService writerService, IWriterloginService writerloginService)
        {
            _adminService = adminService;
            _writerService = writerService;
            _writerloginService = writerloginService;
        }


        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin p)
        {
            var adminUserInfo = _adminService.TGirisYap(p);

            if (adminUserInfo != null)
            {
                FormsAuthentication.SetAuthCookie(adminUserInfo.AdminUserName, false);
                Session["AdminUserName"] = adminUserInfo.AdminUserName;
                return RedirectToAction("Index", "AdminCategory");
            }

            ViewBag.HataliGiris = 1;
            return View();
        }


        public ActionResult WriterLogin()
        {
            return View();
        }


        [HttpPost]
        public ActionResult WriterLogin(Writer writer)
        {


            //var UserInfo = context.Writers.Where(x => x.WriterMail == writer.WriterMail && x.WriterPassword == writer.WriterPassword).FirstOrDefault();

            var UserInfo = _writerloginService.GetWriter(writer.WriterMail, writer.WriterPassword);


            if (UserInfo != null)
            {
                FormsAuthentication.SetAuthCookie(UserInfo.WriterMail, false);
                Session["WriterMail"] = UserInfo.WriterMail;

                return RedirectToAction("AlHeading", "WriterPanel");
            }

            ViewBag.HataliGiris = 1;
            return View();

        }


        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();

            return RedirectToAction("Headings", "Default");

        }

      


    }
}