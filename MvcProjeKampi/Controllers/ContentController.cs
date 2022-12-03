using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    [Authorize]
    public class ContentController : Controller
    {
       private readonly IContentService _contentService;

        private readonly Context _context;

        public ContentController(IContentService contentService, Context context)
        {
            _contentService = contentService;
            _context = context;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ContentByHeading(int id)
        {
           var values= _contentService.TGetListByHeadingId(id);
            return View(values);
        }


        public ActionResult GetAllContent(string p)
        {
            if (p==null)
            {
                var values1 = _contentService.TGetList();
                return View(values1.ToList()); ;
            }

            var values = _contentService.TGetListAll(p);
            return View(values.ToList()); ;
        }

    }
}