using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
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
        // GET: WriterPanelContent
        public ActionResult MyContent(string p
)
        {
            Context c=new Context();
            
            //sisteme giriş yapma
            p = (string)Session["WriterMail"];
            var writerinfo=c.Writers.Where(x=>x.WriterMail == p).Select(y=>y.WriterID)
                .FirstOrDefault();
            var contentvalues = cm.GetListByWriter(writerinfo);
            return View(contentvalues);
        }
    }
}