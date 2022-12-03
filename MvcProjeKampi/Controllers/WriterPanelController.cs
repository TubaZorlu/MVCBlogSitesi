using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using BusinessLayer.ValidationRules;
using FluentValidation.Results;

namespace MvcProjeKampi.Controllers
{

    public class WriterPanelController : Controller
    {
        private readonly IHeadingService _headingService;
        private readonly ICategoryService _CategoryService;
        private readonly IWriterService _writerService;
        private readonly Context _context;


        public WriterPanelController(IHeadingService headingService, ICategoryService categoryService, Context context, IWriterService writerService)
        {
            _headingService = headingService;
            _CategoryService = categoryService;
            _context = context;
            _writerService = writerService;
        }

        [HttpGet]
        public ActionResult WriterProfile()
        {
            string girisYapankullanini = (string)Session["WriterMail"];
            int girisYapanId = _context.Writers.Where(x => x.WriterMail == girisYapankullanini).Select(x => x.WriterID).FirstOrDefault();
            var writer = _writerService.TGetByID(girisYapanId);
            return View(writer);
        }


        [HttpPost]
        public ActionResult WriterProfile(Writer writer)
        {
            WriterValidator validations = new WriterValidator();
            ValidationResult result = validations.Validate(writer);
            if (result.IsValid)
            {


                var value = _writerService.TGetByID(writer.WriterID);
                value.WriterName = writer.WriterName;
                value.WriterSurname = writer.WriterSurname;
                value.WriterMail = writer.WriterMail;
                value.WriterPassword = writer.WriterPassword;
                value.WriterAbout = writer.WriterAbout;
                value.WriterTitle = writer.WriterTitle;
                _writerService.TUpdate(writer);

                return RedirectToAction("MyHeading");
            }

            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();

        }


        public ActionResult MyHeading()
        {
            string girisYapankullanini = (string)Session["WriterMail"];
            int girisYapanId = _context.Writers.Where(x => x.WriterMail == girisYapankullanini).Select(x => x.WriterID).FirstOrDefault();
            var values = _context.Headings.Where(x => x.WriterID == girisYapanId && x.HeadingStatus == true).ToList();
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
            string girisYapankullanini = (string)Session["WriterMail"];
            int girisYapanId = _context.Writers.Where(x => x.WriterMail == girisYapankullanini).Select(x => x.WriterID).FirstOrDefault();

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

        // sayfalama yapacağız,p burada başlangıç değeri diğer 5 kaç adet olacağını belirtiğimiz değer
        //p yi 2 versek bu durumda 2 5 li grubu verirdi
        public ActionResult AlHeading(int p = 1)
        {
            var headigs = _headingService.TGetList().ToPagedList(p, 5);
            return View(headigs);
        }
    }
}