using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProje.Models.Sınıflar;
namespace TravelTripProje.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        Context c = new Context();  
        [Authorize]
        public ActionResult Index()
        {
            var degerler = c.Blogs.ToList();
            return View(degerler);
        }
        [HttpGet]
        [Authorize]
        public ActionResult YeniBlog()
        {
           
            return View();
        }
        [HttpPost]
        [Authorize]
        public ActionResult YeniBlog(Blog p)
        {
            c.Blogs.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize]
        public ActionResult BlogSil(int id)
        {
            var blog = c.Blogs.Find(id);
            c.Blogs.Remove(blog);
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        [Authorize]
        public ActionResult BlogGetir(int id)
        {
            var blog = c.Blogs.Find(id);
            return View("BlogGetir",blog);

        }
        [Authorize]
        public ActionResult BlogGuncelle(Blog b)
        {
            var blg = c.Blogs.Find(b.ID);
            blg.Aciklama = b.Aciklama;
            blg.Baslik = b.Baslik;
            blg.BlogImage = b.BlogImage;    
            blg.Tarih = b.Tarih;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize]
        public ActionResult YorumListesi()
        {
            var yorumlar = c.Yorumlars.ToList();
            return View(yorumlar);
        }
        [Authorize]
        public ActionResult YorumSil(int id)
        {
            var yorum = c.Yorumlars.Find(id);
            c.Yorumlars.Remove(yorum);
            c.SaveChanges();
            return RedirectToAction("YorumListesi");

        }
        [Authorize]
        public ActionResult YorumOnay(int id)
        {
            var yorum = c.Yorumlars.Find(id);
            yorum.Onay = true;
            c.SaveChanges();
            return RedirectToAction("YorumListesi");

        }
        [Authorize]
        public ActionResult YorumGetir(int id)
        {
            var yorum = c.Yorumlars.Find(id);
            
          
            return View("YorumGetir", yorum);

        }
        [Authorize]
        public ActionResult YorumGuncelle(Yorumlar y)
        {

            var yrm = c.Yorumlars.Find(y.ID);
            yrm.KullaniciAdi = y.KullaniciAdi;
            yrm.Yorum = y.Yorum;
            yrm.Mail = y.Mail;
            yrm.Onay = y.Onay;
            c.SaveChanges();
            return RedirectToAction("YorumListesi");
        }
    }
}