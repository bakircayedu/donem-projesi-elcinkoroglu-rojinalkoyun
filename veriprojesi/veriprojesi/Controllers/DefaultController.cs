using System;
using veriprojesi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace veriprojesi.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Hizmetlerimiz()
        {
            return View();
        }
        public ActionResult Randevu()
        {
            return View();
        }
        public ActionResult Iletisim()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Randevu(FormCollection form)
        {
            DbGuzellikSalonuEntities db = new DbGuzellikSalonuEntities();
            Musteri model = new Musteri();
            Randevu randevu = new Randevu();
            Islem islem = new Islem();
            model.ad = form["ad"];
            model.soyad = form["soyad"];
            model.email = form["email"].Trim();
            randevu.musteri_id = model.musteri_id;
            randevu.ıslem_id =Convert.ToInt32( form["islem_id"].ToString());
            randevu.randevu_tarih= Convert.ToDateTime(form["randevutarih"].ToString());
            db.Musteri.Add(model);
            db.Randevu.Add(randevu);
            db.SaveChanges();
            return View();
          }
    


    }
}