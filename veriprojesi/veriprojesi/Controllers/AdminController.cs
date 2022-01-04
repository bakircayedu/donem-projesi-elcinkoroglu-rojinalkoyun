using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using veriprojesi.Models;

namespace veriprojesi.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            using (DbGuzellikSalonuEntities db =  new DbGuzellikSalonuEntities())
            {
                var model  = db.Musteri.ToList();
                return View(model);
            }
         }
        public ActionResult Ekle()
        {
            
                var model = new Musteri();
                return View("UrunForm",model);
            
        }
        public ActionResult RandevuEkle()
        {

            var model = new Randevu();
            return View("RandevuForm", model);

        }
        public ActionResult Guncelle(int musteri_id)
        {
            using (DbGuzellikSalonuEntities db = new DbGuzellikSalonuEntities())
            {
                var model = db.Musteri.Find(musteri_id);
                if(model == null)
                {
                   return HttpNotFound();
                }
                return View("UrunForm", model);
            }
        }
        public ActionResult RandevuGuncelle(int randevu_id)
        {
            using (DbGuzellikSalonuEntities db = new DbGuzellikSalonuEntities())
            {
                var model = db.Randevu.Find(randevu_id);
                if (model == null)
                {
                    return HttpNotFound();
                }
                return View("RandevuForm", model);
            }
        }
        public ActionResult Kaydet(Musteri yeni_musteri)
        {

            using (DbGuzellikSalonuEntities db = new DbGuzellikSalonuEntities())
            {
                if (!ModelState.IsValid)
                {
                    return View("UrunForm", yeni_musteri);
                }
                if (yeni_musteri.musteri_id == 0)
                {
                    db.Musteri.Add(yeni_musteri);
                }
                else
                {
                    var guncel_musteri = db.Musteri.Find(yeni_musteri.musteri_id);
                    db.Entry(guncel_musteri).CurrentValues.SetValues(yeni_musteri);
                }
                    
                    
                
                db.SaveChanges();
                return RedirectToAction("index");
            }

        }
        public ActionResult RandevuKaydet(Randevu yeni_randevu)
        {

            using (DbGuzellikSalonuEntities db = new DbGuzellikSalonuEntities())
            {
                if (!ModelState.IsValid)
                {
                    return View("RandevuForm", yeni_randevu);
                }
                if (yeni_randevu.randevu_id == 0)
                {
                    db.Randevu.Add(yeni_randevu);
                }
                else
                {
                    var guncel_randevu = db.Randevu.Find(yeni_randevu.randevu_id);
                    db.Entry(guncel_randevu).CurrentValues.SetValues(yeni_randevu);
                }



                db.SaveChanges();
                return RedirectToAction("RandevuListe");
            }

        }

        public ActionResult Sil(int musteri_id)
        {
            using (DbGuzellikSalonuEntities db = new DbGuzellikSalonuEntities())
            {
               
                var silinecek_musteri = db.Musteri.Find(musteri_id);
                if (silinecek_musteri == null)
                {
                    return HttpNotFound();
                }
            
                db.Musteri.Remove(silinecek_musteri);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        public ActionResult RandevuListe()
        {
      
                using (DbGuzellikSalonuEntities db = new DbGuzellikSalonuEntities())
                {
                    var model1 = db.Randevu.ToList();
                    return View(model1);
                }
            }
        public ActionResult RandevuSil(int randevu_id)
        {
            using (DbGuzellikSalonuEntities db = new DbGuzellikSalonuEntities())
            {

                var silinecek_randevu = db.Randevu.Find(randevu_id);
                if (silinecek_randevu == null)
                {
                    return HttpNotFound();
                }

                db.Randevu.Remove(silinecek_randevu);
                db.SaveChanges();
                return RedirectToAction("RandevuListe");
            }
        }

    }
    }
