using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class DefaultController : Controller
    {
        //herkesin erişebileceği sayfa 


        private readonly IHeadingService _headingService;
        private readonly IContentService _contentService;
        private readonly Context _context;

        public DefaultController(IHeadingService headingService, IContentService contentService, Context context)
        {
            _headingService = headingService;
            _contentService = contentService;
            _context = context;
        }

        public ActionResult Headings()
        {
            var headigList = _headingService.TGetList();
            return View(headigList);
        }

        public PartialViewResult Index(int id=0)
        {
            var contentList = _context.Contents.Where(x => x.HeadingID == id).ToList();

            return PartialView(contentList);
        }
    }
}