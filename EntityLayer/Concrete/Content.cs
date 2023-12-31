﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Content //içerik sınıfı
    {
        [Key]
        public int  ContentID { get; set; }
        [StringLength(100)]
        public string ContentValue { get; set; }
        public DateTime ContentDate { get; set; }
        public bool ContentStatus { get; set; }

        //ilişki yaptığımız tablodaki anahtarla aynı ismi veriyoruz
        public int HeadingID { get; set; }
        //ilişkide olup olmadığını anlama
        public virtual Heading Heading { get; set; }

        //ilişki yaptığımız tablodaki anahtarla aynı ismi veriyoruz
        public int? WriterID { get; set; }
        //ilişkide olup olmadığını anlama
        public virtual Writer Writer { get; set; }
    }
}
