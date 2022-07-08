using System.ComponentModel.DataAnnotations;

namespace KisiselWebProjesi.Models.Siniflar
{
    public class AnaSayfa
    {
        [Key]
        public int ID { get; set; }
        public string  profil { get; set; }
        public string isim { get; set; }
        public string unvan { get; set; }
        public string aciklama { get; set; }
        public string iletisim { get; set; }
    }
}