using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
   
    public class HeadingController : Controller
    {
        IHeadingService _headingService;
        ICategoryService _CategoryService;
        IWriterService _writerService;

        public HeadingController(IHeadingService headingService, ICategoryService categoryService, IWriterService writerService)
        {
            _headingService = headingService;
            _CategoryService = categoryService;
            _writerService = writerService;
        }

        public ActionResult Index()
        {
            var values = _headingService.TGetList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> valueCategory = (from x in _CategoryService.TGetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }
                                                 ).ToList();

            List<SelectListItem> valueWriter = (from x in _writerService.TGetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.WriterName+" "+x.WriterSurname,
                                                      Value = x.WriterID.ToString()
                                                  }
                                                         ).ToList();

            ViewBag.category = valueCategory;
            ViewBag.writer = valueWriter;

            return View();
        }

        [HttpPost]
        public ActionResult AddHeading(Heading heading)
        {
            heading.HeadingDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());

            _headingService.TInsert(heading);
            return RedirectToAction("Index");
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
            _headingService.TUpdate(headingValue);

            return RedirectToAction("Index");


        }

        public ActionResult DeleteHeading(int id) 
        {
            var headingValue = _headingService.TGetByID(id);
            if (headingValue.HeadingStatus==false) headingValue.HeadingStatus = true;
            else headingValue.HeadingStatus = false;

            // sadece kaydetme iş
            _headingService.TUpdate(headingValue);
            return RedirectToAction("Index");
        }


    }
}