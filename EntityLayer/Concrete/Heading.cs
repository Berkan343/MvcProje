using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Heading
    {
        [Key]
        public int HeadingID { get; set; }
        [StringLength(100)]
        public string HeadingName { get; set; }
        public DateTime HeadingDate { get; set; }

        //ilişki yaptığımız tablodaki anahtarla aynı ismi veriyoruz
        public int CategoryID { get; set; }
        //ilişkide olup olmadığını anlama
        public virtual Category Category { get; set; }
        //heading ile de content ilişki halinde 
        public ICollection<Content> Contents { get; set; }

        //ilişki yaptığımız tablodaki anahtarla aynı ismi veriyoruz
        public int WriterID { get; set; }
        //ilişkide olup olmadığını anlama
        public virtual Writer Writer { get; set; }
    }
}
