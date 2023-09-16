using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        HeadingManager hm = new HeadingManager(new EFHeadingDal());
        ContentManager cm = new ContentManager(new EFContentDal());

        // GET: Default
        public ActionResult Headings()
        {
            var headinglist=hm.GetList();
            return View(headinglist);
        }
        public PartialViewResult Index(int id=0)
        {
            var contentlist=cm.GetListByHeadingID(id);
            return PartialView(contentlist);
        }
    }
}