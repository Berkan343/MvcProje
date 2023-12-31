﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Contact //iletişim sınıfı
    {
        [Key]
        public int ContactID { get; set; }
        [StringLength(100)]
        public string UserName { get; set; }
        [StringLength(100)]
        public string UserMail { get; set; }
        public DateTime ContactDate { get; set; }
        [StringLength(100)]
        public string Subject { get; set; }
        [StringLength(100)]
        public string Message { get; set; }

    }
}
