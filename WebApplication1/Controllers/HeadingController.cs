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
        WriterManager wm = new WriterManager(new EFWriterDal());


        public ActionResult Index()
        {
            var headingvalues = hm.GetList();
            return View(headingvalues);
        }
       
        [HttpGet]
        public ActionResult AddHeading()
        {
            //DropDownList tanımlaması
            List<SelectListItem>valuecategory=(from x in cm.GetList()
                                               select new SelectListItem
                                               {
                                                   Text=x.CategoryName,
                                                   Value=x.CategoryID.ToString()
                          
                                               }).ToList();
            List<SelectListItem> valuewriter = (from x in wm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.WriterName+" "+x.WriterSurName,
                                                      Value = x.WriterID.ToString()

                                                  }).ToList();
            ViewBag.vlc=valuecategory;
            ViewBag.vlw = valuewriter;

            return View();

        }
        [HttpPost]
        public ActionResult AddHeading(Heading p)
        {
            p.HeadingDate =DateTime.Parse(DateTime.Now.ToShortDateString());
                hm.HeadingAdd(p);
                return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> valuecategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()

                                                  }).ToList();
            ViewBag.vlc = valuecategory;
            var HeadingValue =hm.GetByID(id);
            return View(HeadingValue);
        }
        [HttpPost]
        public ActionResult EditHeading(Heading p)
        {
            hm.HeadingUpdate(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteHeading(int id)
        {
            var HeadingValue=hm.GetByID(id);
            hm.HeadingDelete(HeadingValue);
            return RedirectToAction("Index");

        }



    }

}