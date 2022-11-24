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
    public class WriterPanelMessageController : Controller
    {
        private readonly IMessageService _messageService;

        public WriterPanelMessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Inbox()
        {
            var messageList = _messageService.TGetlistInbox();
            return View(messageList);
        }

        public ActionResult InboxDetails(int id)
        {
            var messageDetails = _messageService.TGetByID(id);
            return View(messageDetails);
        }


        public ActionResult Sendbox()
        {
            var messageList = _messageService.TGetlistSendbox();
            return View(messageList);
        }

        public ActionResult SendBoxDetails(int id)
        {
            var messageDetails = _messageService.TGetByID(id);
            return View(messageDetails);

        }

        public PartialViewResult MessageListMenu()
        {
            using (var context = new Context())
            {
                string girisYapankullanini = (string)Session["WriterMail"];
                ViewBag.gelen = context.Meassages.Where(x => x.ReceiverMail == girisYapankullanini).Count();
                ViewBag.giden = context.Meassages.Where(x => x.SenderMail == girisYapankullanini).Count();
            }
            return PartialView();
        }




        [HttpGet]
        public ActionResult NewMessage()
        {

            return View();
        }


        [HttpPost]
        public ActionResult NewMessage(Meassage meassage)
        {
            MessageValidator validationRules = new MessageValidator();
            ValidationResult result = validationRules.Validate(meassage);
            if (result.IsValid)
            {

                meassage.Date = Convert.ToDateTime(DateTime.Now);
                meassage.SenderMail = (string)Session["WriterMail"];
                _messageService.TInsert(meassage);
                return RedirectToAction("Sendbox");

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