using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        [StringLength(100)]
        public string CategoryName { get; set; }
        [StringLength(100)]
        public string CategoryDescription { get; set; }
        
        //pasiflik durumu için bool
        public bool CategoryStatus { get; set; }

        //category ile heading ile ilişki kurmak için--> 1:m ilişki
        public ICollection<Heading> Headings { get; set; }

    }
}
