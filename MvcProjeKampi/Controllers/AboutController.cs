using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AboutController : Controller
    {
        IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }


        public ActionResult Index()
        {
            var aboutValues = _aboutService.TGetList();
            return View(aboutValues);
        }

        [HttpGet]
        public ActionResult AddAbout( )
        {
          
            return View();
        } 

        [HttpPost]
        public ActionResult AddAbout(About about)
        {
            _aboutService.TInsert(about);

            return RedirectToAction("Index");
        }

        // Ekleme işlemine popup da yapmak için bu partial ı kullandık 
        public PartialViewResult AboutPartial() 
        {
            return PartialView();
        }
    }
}