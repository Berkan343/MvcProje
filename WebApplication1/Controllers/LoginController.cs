﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer.Concrete;
using System.Web.Security;
using DataAccessLayer.EntityFramework;
using BusinessLayer.Concrete;

namespace WebApplication1.Controllers
{
    [AllowAnonymous]

    public class LoginController : Controller
    {
        WriterLoginManager wm =new WriterLoginManager(new EFWriterDal());
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin p)
        {
            Context c = new Context();
            var adminuserinfo = c.Admins.FirstOrDefault(x => x.AdminUserName == p.AdminUserName &&
            x.AdminPassword==p.AdminPassword);
            if(adminuserinfo!=null)
            {
                //sisteme giriş yapma sayfaları görmek için
                FormsAuthentication.SetAuthCookie(adminuserinfo.AdminUserName,false);
                Session["AdminUserName"]=adminuserinfo.AdminUserName;
                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                return RedirectToAction("Index");
            }
            
        }
        //yazar için login işlemi
        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult WriterLogin(Writer p)
        {
            //Context c = new Context();
            //var writeruserinfo = c.Writers.FirstOrDefault(x => x.WriterMail == p.WriterMail &&
            //x.WriterPassword == p.WriterPassword);
            var writeruserinfo=wm.GetWriter(p.WriterMail,p.WriterPassword);
            if (writeruserinfo != null)
            {
                //sisteme giriş yapma sayfaları görmek için
                FormsAuthentication.SetAuthCookie(writeruserinfo.WriterMail, false);
                Session["WriterMail"] = writeruserinfo.WriterMail;
                return RedirectToAction("MyContent", "WriterPanelContent");
            }
            else
            {
                return RedirectToAction("WriterLogin");
            }
            
        }
        public ActionResult LogOut()
        {
           FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Headings", "Default");
        }
    }
}