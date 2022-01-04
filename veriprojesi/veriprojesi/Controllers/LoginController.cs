using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using veriprojesi.Models;
using System.Web.Security;

namespace veriprojesi.Controllers
{
    public class LoginController : Controller
    {
        // GET: admin/Login
        public ActionResult Index()
        {
            return View ();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Alogin(SistemAdmini adminFormu)
        {   using (DbGuzellikSalonuEntities db = new DbGuzellikSalonuEntities())
            {
                var kullanicikontrol = db.SistemAdmini.FirstOrDefault(
                    s => s.kullanici_adi == adminFormu.kullanici_adi && s.sifre == adminFormu.sifre );

                if( kullanicikontrol != null)
                {
                    FormsAuthentication.SetAuthCookie(kullanicikontrol.kullanici_adi, false);
                    return RedirectToAction("/index", "admin");
                }
                ViewBag.Hata = "Kullanıcı adı veya şifre hatalı";
                return View("index");
            }
               
        }
        public ActionResult AdminEkle()
        {

            var model = new SistemAdmini();
            return View("AdminForm", model);

        }
        public ActionResult AdminDuzenle(int admin_id)
        {
            using (DbGuzellikSalonuEntities db = new DbGuzellikSalonuEntities())
            {
                var model = db.SistemAdmini.Find(admin_id);
                if (model == null)
                {
                    return HttpNotFound();
                }
                return View("AdminForm", model);
            }
        }
        public ActionResult AdminKaydet(SistemAdmini yeni_admin)
        {

            using (DbGuzellikSalonuEntities db = new DbGuzellikSalonuEntities())
            {
                if (!ModelState.IsValid)
                {
                    return View("AdminForm", yeni_admin);
                }
                if (yeni_admin.admin_id == 0)
                {
                    db.SistemAdmini.Add(yeni_admin);
                }
                else
                {
                    var guncel_admin = db.SistemAdmini.Find(yeni_admin.admin_id);
                    db.Entry(guncel_admin).CurrentValues.SetValues(yeni_admin);
                }



                db.SaveChanges();
                return RedirectToAction("AdminListe");
            }

        }
        public ActionResult AdminListe()
        {

            using (DbGuzellikSalonuEntities db = new DbGuzellikSalonuEntities())
            {
                var model1 = db.SistemAdmini.ToList();
                return View(model1);
            }
        }
        public ActionResult AdminSil(int admin_id)
        {
            using (DbGuzellikSalonuEntities db = new DbGuzellikSalonuEntities())
            {

                var silinecek_admin= db.SistemAdmini.Find(admin_id);
                if (silinecek_admin == null)
                {
                    return HttpNotFound();
                }

                db.SistemAdmini.Remove(silinecek_admin);
                db.SaveChanges();
                return RedirectToAction("AdminListe");
            }
        }
    }
}