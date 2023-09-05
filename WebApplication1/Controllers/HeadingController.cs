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
        CategoryManager cm = new CategoryManager(new EfCategoryDal());

        public ActionResult Index()
        {
            var headingvalues = hm.GetList();
            return View(headingvalues);
        }
       
        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem>valuecategory=(from x in cm.GetList()
                                               select new SelectListItem
                                               {
                                                   Text=x.CategoryName,
                                                   Value=x.CategoryID.ToString()
                                               }).ToList();
            return View();
        }
        [HttpPost]
        public ActionResult AddHeading(Heading p)
        {
            p.HeadingDate =DateTime.Parse(DateTime.Now.ToShortDateString());
                hm.HeadingAdd(p);
                return RedirectToAction("Index");
        }
            
        }
    
}