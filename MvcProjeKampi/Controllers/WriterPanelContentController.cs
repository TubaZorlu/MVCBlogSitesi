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
    public class WriterPanelContentController : Controller
    {
        private readonly IContentService _contentService;
        private readonly Context _context;


        public WriterPanelContentController(IContentService contentService, Context context)
        {
            _contentService = contentService;
            _context = context;


        }
        public ActionResult MyContent()
        {
            string girisYapankullanini = (string)Session["WriterMail"];
            int girisYapanId = _context.Writers.Where(x => x.WriterMail == girisYapankullanini).Select(x => x.WriterID).FirstOrDefault();

            var values = _context.Contents.Where(x => x.WriterID == girisYapanId).ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.HeadingName = _context.Headings.Where(x => x.HeadingID == id).Select(x => x.HeadingName).FirstOrDefault();
            ViewBag.İd = id;
            return View();
        }


        [HttpPost]
        public ActionResult AddContent(Content content)
        {
            string girisYapankullanini = (string)Session["WriterMail"];
            int girisYapanId = _context.Writers.Where(x => x.WriterMail == girisYapankullanini).Select(x => x.WriterID).FirstOrDefault();

            content.ContentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            content.WriterID = girisYapanId;
            content.ContentStatus = true;

            _contentService.TInsert(content);
            return RedirectToAction("MyContent");
        }

        //profilim sayfası yok
        //tüm başlıklarda page yapıalcak
        //session göre mesajben yaptım 
        //oturum yönetimini mimamiye taşıma
        //token kullanıkı
        //


    }
}