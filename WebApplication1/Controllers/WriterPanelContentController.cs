using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class WriterPanelContentController : Controller
    {
        ContentManager cm = new ContentManager(new EFContentDal());
        Context c = new Context();
        // GET: WriterPanelContent
        public ActionResult MyContent(string p
)
        {
            
            
            //sisteme giriş yapma
            p = (string)Session["WriterMail"];
            var writerinfo=c.Writers.Where(x=>x.WriterMail == p).Select(y=>y.WriterID)
                .FirstOrDefault();
            var contentvalues = cm.GetListByWriter(writerinfo);
            return View(contentvalues);
        }
        [HttpGet]
        public ActionResult AddContent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddContent(Content p)
        {
            string mail = (string)Session["WriterMail"];
            var writerinfo = c.Writers.Where(x => x.WriterMail == mail).Select(y => y.WriterID)
                .FirstOrDefault();
            p.ContentDate=DateTime.Parse(DateTime.Now.ToShortDateString());
            p.WriterID = writerinfo;
            p.ContentStatus = true;
            cm.ContentyAdd(p);
            return RedirectToAction("MyContent");
        }
    }
}