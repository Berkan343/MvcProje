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
    public class HeadingController : Controller
    {
        
        HeadingManager hm = new HeadingManager(new EFHeadingDal());
        // GET: Category
        public ActionResult Index()
        {
            var headingvalues = hm.GetList();
            return View(headingvalues);
        }
       
        [HttpGet]
        public ActionResult AddHeading()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddHeading(Heading p)
        {
            
                hm.HeadingAdd(p);
                return RedirectToAction("Index");
            }
            
        }
    
}