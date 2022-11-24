using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    [Authorize]
    public class WriterController : Controller
    {
      private readonly IWriterService _writerService;

        public WriterController(IWriterService writerService)
        {
            _writerService = writerService;
        }

        public ActionResult Index()
        {
            var values = _writerService.TGetList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddWriter()
        {
           
            return View();
        }

        [HttpPost]
        public ActionResult AddWriter(Writer writer)
        {
            WriterValidator validations = new WriterValidator();
            ValidationResult result = validations.Validate(writer);
            if (result.IsValid)
            {
                _writerService.TInsert(writer);
                return RedirectToAction("Index");
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

        [HttpGet]
        public ActionResult EditWriter(int id)
        {
            var value = _writerService.TGetByID(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult EditWriter(Writer writer)
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

                return RedirectToAction("Index");
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

    }
}