using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContentService
    {
        List<Content> GetList();
        List<Content> GetListByHeadingID(int id);


        void ContentyAdd(Content content);
        //Silinecek veriyi buldurma id ye göre
        Content GetByHeadingID(int id);
        void ContentDelete(Content content);
        void ContentyUpdate(Content content);
    }
}
