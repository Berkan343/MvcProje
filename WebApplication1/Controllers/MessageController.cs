using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;

using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace WebApplication1.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message
        MessageManager mm = new MessageManager(new EFMessageDal());
        MessageValidator messagevalidator = new MessageValidator();

        [Authorize]
        public ActionResult Inbox(string p)
        {
            var messagelist = mm.GetListInbox(p);
            return View(messagelist);
        }
        public ActionResult Sendbox(string p)
        {
            var messagelist = mm.GetListSendbox(p);
            return View(messagelist);
        }
        public ActionResult GetInboxMessageDetails(int id)
        {
            var values = mm.GetByID(id);
            return View(values);

        }
        public ActionResult GetSendboxMessageDetails(int id)
        {
            var values = mm.GetByID(id);
            return View(values);

        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult NewMessage(Message p)
        {
            ValidationResult results = messagevalidator.Validate(p);
            if (results.IsValid)
            {
                p.SenderMail= "emel@gmail.com";
                p.MessageDate=DateTime.Parse( DateTime.Now.ToShortDateString());
                mm.MessageAdd(p);
                return RedirectToAction("SendBox");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}