using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    
    public class AdminCategoryController : Controller
    {
        ICategoryService _categoryService;


        public AdminCategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [Authorize]
        public ActionResult Index()
        {
            var values = _categoryService.TGetList();
            return View(values);
        }

        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            CategoryValidator validationRules = new CategoryValidator();
            ValidationResult result = validationRules.Validate(category);
            if (result.IsValid)
            {
                _categoryService.TInsert(category);
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


        public ActionResult DeleteCategory(int id)
        {

            var values = _categoryService.TGetByID(id);
            _categoryService.TDelete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var values = _categoryService.TGetByID(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateCategory(Category category)
        {
            //entitystate çalışmadığı için bunu yazdım
            var values = _categoryService.TGetByID(category.CategoryID);
            values.CategoryName = category.CategoryName;
            values.CategoryDescription = category.CategoryDescription;
            values.CategoryStatus = true;
            _categoryService.TUpdate(category);
            return RedirectToAction("Index");
        }





    }
}