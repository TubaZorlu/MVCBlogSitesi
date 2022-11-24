using BusinessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    [Authorize]
    public class GaleryController : Controller
    {
        IImageFileService imageFileService;

        public GaleryController(IImageFileService imageFileService)
        {
            this.imageFileService = imageFileService;
        }

        public ActionResult Index()
        {
            var files = imageFileService.TGetList();
            return View(files);
        }
    }
}