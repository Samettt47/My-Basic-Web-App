using KisiselWebProjesi.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KisiselWebProjesi.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var deger = c.AnaSayfas.ToList();
            return View(deger);
        }

        public ActionResult AnaSayfaGetir(int ID)
        {
            var ag = c.AnaSayfas.Find(ID);
            return View("AnaSayfaGetir" , ag);

        }
        
        public ActionResult AnaSayfaGuncelle(AnaSayfa x)
        {
            var ag = c.AnaSayfas.Find(x.ID);
            ag.isim = x.isim;
            ag.profil = x.profil;
            ag.unvan = x.unvan;
            ag.aciklama = x.aciklama;
            ag.iletisim = x.iletisim;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ikonlistesi()
        {
            var deger = c.Ikonlars.ToList();
            return View(deger);


        }
        [HttpGet] // sayfa yüklendiğinde çalışsın demek
        public ActionResult YeniIkon()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniIkon(Ikonlar p)
        {
            c.Ikonlars.Add(p);
            c.SaveChanges();
            return RedirectToAction("ikonlistesi");
        }
        public ActionResult ikonGetir(int id)
        {
            var ig = c.Ikonlars.Find(id);
            return View("ikonGetir", ig);

        }
        public ActionResult ikonGuncelle(Ikonlar x)

        {
            var ig = c.Ikonlars.Find(x.ID);
            ig.ikon = x.ikon;
            ig.Link = x.Link;
            c.SaveChanges();
            return RedirectToAction("ikonlistesi");

        }

        public ActionResult ikonSil(int id)
        {
            var sl = c.Ikonlars.Find(id);
            c.Ikonlars.Remove(sl);
            c.SaveChanges();
            return RedirectToAction("ikonlistesi");

        }

    }
}