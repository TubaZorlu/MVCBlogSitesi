using BusinessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class WriterPanelContentController : Controller
    {
        private readonly IContentService _contentService;

        public WriterPanelContentController(IContentService contentService)
        {
            _contentService = contentService;
        }
        public ActionResult MyContent(int id)
        {
            var values = _contentService.TGetListByHeadingId(id);
            return View(values);
        }

        
    }
}