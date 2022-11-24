using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{

    public class WriterPanelController : Controller
    {
        private readonly IHeadingService _headingService;
        private readonly ICategoryService _CategoryService;

        public WriterPanelController(IHeadingService headingService, ICategoryService categoryService)
        {
            _headingService = headingService;
            _CategoryService = categoryService;
        }

        public ActionResult WriterProfile()
        {
            return View();
        }

        int girisYapanId;
        public ActionResult MyHeading()
        {
            string girisYapankullanini = (string)Session["WriterMail"];

            var context = new Context();

             girisYapanId = context.Writers.Where(x => x.WriterMail == girisYapankullanini).Select(x => x.WriterID).FirstOrDefault();
            var values = _headingService.TGetListByWriter(girisYapanId);
           

            return View(values);




        }

        [HttpGet]
        public ActionResult NewHeading()
        {
            List<SelectListItem> valueCategory = (from x in _CategoryService.TGetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }
                                                ).ToList();

            ViewBag.category = valueCategory;
            return View();
        }

        [HttpPost]
        public ActionResult NewHeading(Heading heading)
        {
            heading.HeadingDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            heading.WriterID = girisYapanId;
            heading.HeadingStatus = true;
            _headingService.TInsert(heading);
            return RedirectToAction("MyHeading");
        }



        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> valueCategory = (from x in _CategoryService.TGetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }
                                                 ).ToList();

            ViewBag.category = valueCategory;

            var headingValue = _headingService.TGetByID(id);
            return View(headingValue);


        }

        [HttpPost]
        public ActionResult EditHeading(Heading heading)
        {
            var headingValue = _headingService.TGetByID(heading.HeadingID);

            headingValue.HeadingName = heading.HeadingName;
            headingValue.CategoryID = heading.CategoryID;
            headingValue.HeadingDate = headingValue.HeadingDate;
            headingValue.WriterID = headingValue.WriterID;
            heading.WriterID = girisYapanId;
            _headingService.TUpdate(headingValue);

            return RedirectToAction("MyHeading");


        }

        public ActionResult DeleteHeading(int id)
        {
            var headingValue = _headingService.TGetByID(id);
            headingValue.HeadingStatus = false;

            // sadece kaydetme iş
            _headingService.TUpdate(headingValue);
            return RedirectToAction("MyHeading");
        }
    }
}