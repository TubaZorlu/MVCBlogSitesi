using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System.Web.Mvc;


namespace MvcProjeKampi.Controllers
{
    public class CategoryController : Controller
    {
        ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetCategoryList()
        {
            var categoryValues = _categoryService.TGetList();
            return View(categoryValues);
        }


        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category category)
        {

            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult result = categoryValidator.Validate(category);

            if (result.IsValid)
            {
                _categoryService.TInsert(category);
                return RedirectToAction("GetCategoryList");
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