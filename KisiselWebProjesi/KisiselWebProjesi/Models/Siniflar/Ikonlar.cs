using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KisiselWebProjesi.Models.Siniflar
{
    public class Ikonlar
    {
        [Key]
        public int ID { get; set; }
        public string ikon { get; set; }
        public string Link { get; set; }
    }
}