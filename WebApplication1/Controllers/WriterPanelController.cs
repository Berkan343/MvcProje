using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using BusinessLayer.ValidationRules;
using FluentValidation.Results;

namespace WebApplication1.Controllers
{
    public class WriterPanelController : Controller
    {
        HeadingManager hm=new HeadingManager(new EFHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EFWriterDal());

        Context c = new Context();
        int writeridinfo;
        // GET: WriterPanel
        [HttpGet]

        public ActionResult WriterProfile(int id)
        {
            string p = (string)Session["WriterMail"];
            id = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();

            var writervalue = wm.GetByID(id);

            return View(writervalue);
        }
        [HttpPost]
        public ActionResult WriterProfile(Writer p)
        {
            WriterValidator writervalidator = new WriterValidator();

            ValidationResult results = writervalidator.Validate(p);
            if (results.IsValid)
            {
                wm.WriterUpdate(p);
                return RedirectToAction("AllHeading","WriterPanel");
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
        public ActionResult MyHeading(string p)
        {
            p = (string)Session["WriterMail"];
            writeridinfo = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
            var values=hm.GetListByWriter(writeridinfo);
            return View(values);
        }
        [HttpGet]
        public ActionResult NewHeading()
        { 
            List<SelectListItem> valuecategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()

                                                  }).ToList();
            ViewBag.vlc = valuecategory;
            return View();
        }
        [HttpPost]
        public ActionResult NewHeading(Heading p)
        {
            p.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.WriterID = writeridinfo;
            p.HeadingStatus = true;
            hm.HeadingAdd(p);
            return RedirectToAction("MyHeading");
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
            var HeadingValue = hm.GetByID(id);
            return View(HeadingValue);
        }
        [HttpPost]
        public ActionResult EditHeading(Heading p)
        {
            hm.HeadingUpdate(p);
            return RedirectToAction("MyHeading");
        }
        public ActionResult DeleteHeading(int id)
        {
            var HeadingValue = hm.GetByID(id);
            HeadingValue.HeadingStatus = false;
            hm.HeadingDelete(HeadingValue);
            return RedirectToAction("MyHeading");

        }
        public ActionResult AllHeading(int sayfa=1)
        {
            var headings = hm.GetList().ToPagedList(sayfa,4);
            return View(headings);  
        }
    }
}