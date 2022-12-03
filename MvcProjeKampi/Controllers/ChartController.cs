using DataAccessLayer.Concrete;
using MvcProjeKampi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ChartController : Controller
    {
        Context _context;

        public ChartController(Context context)
        {
            _context = context;
        }

        // GET: Chart
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult GrafikOlustur()
        {
            return Json(Kategoriler(), JsonRequestBehavior.AllowGet);
        }


        public List<ContentVM> Kategoriler()
        {
            List<ContentVM> list = new List<ContentVM>();

            list = _context.Categories.Select(x => new ContentVM
            {

                CategoryName = x.CategoryName,
                HeadingCout = x.Headings.Count()

            }).ToList();

            return list;

        }

    }
}