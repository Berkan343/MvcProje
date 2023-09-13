using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class WriterPanelController : Controller
    {
        HeadingManager hm=new HeadingManager(new EFHeadingDal());
        // GET: WriterPanel
        public ActionResult WriterProfile()
        {
            return View();
        }
        public ActionResult MyHeading(int id)
        {
            id = 2;
            var values=hm.GetListByWriter(id);
            return View(values);
        }
    }
}