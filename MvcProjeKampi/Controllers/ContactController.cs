using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    [Authorize]
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        ContactValidator validationRules = new ContactValidator();

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public ActionResult Index()
        {


            var contactValues = _contactService.TGetList();
            return View(contactValues);


        }


        public ActionResult ContactDetails(int id)
        {
            var contactValues = _contactService.TGetByID(id);
            return View(contactValues);
        }

        public PartialViewResult MessageListMenu()
        {
            using (var context = new Context())
            {
                ViewBag.iletisim = context.Contacts.Count();
                ViewBag.gelen = context.Meassages.Where(x => x.ReceiverMail == "admin@gmail.com").Count();
                ViewBag.giden = context.Meassages.Where(x => x.SenderMail == "admin@gmail.com").Count();
               
            }
            return PartialView();
        }


    }
}