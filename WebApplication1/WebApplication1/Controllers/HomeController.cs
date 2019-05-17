using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using WebApplication1.Models;
using System.Net;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        Thicuoiki_WebEntities2 db = new Thicuoiki_WebEntities2();
        // GET: Home 
        public ActionResult Index()
        {
            List<SanPham> sp = db.SanPhams.ToList<SanPham>();
            return View(sp);
        }

        // GET: Home/Details/5
        public ActionResult Details(string ma)
        {
            SanPham sp = db.SanPhams.Find(ma);
            if(sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(sp);
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            ViewBag.Loai = new SelectList(db.LoaiSPs, "maLoai", "tenLoai");
            return View();
        }

        // POST: Home/Create
        [HttpPost]
      
        public ActionResult Create(SanPham sp,FormCollection f)
        {
            
            
             if(ModelState.IsValid)
            {
                db.SanPhams.Add(sp);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Loai = new SelectList(db.LoaiSPs, "maLoai", "tenLoai",sp.maLoai);
            return View(sp);
        }

        // GET: Home/Edit/5
        public ActionResult Edit(string ma)
        {
            if(ma == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            SanPham sp = db.SanPhams.Find(ma);
            if(sp == null)
            {
                return HttpNotFound();
            }
            ViewBag.sp = new SelectList(db.LoaiSPs, "maLoai", "tenLoai", sp.maLoai);
            return View(sp);
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "maSP,tenSP,namSX,GiaSP,hinhAnh,maLoai")] SanPham sp)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sp);
        }

        // GET: Home/Delete/5
        public ActionResult Delete(string ma)
        {
            if(ma == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sp = db.SanPhams.Find(ma);
            if(sp == null)
            {
                return HttpNotFound();
            }
            return View(sp);
        }

        // POST: Home/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirme(string ma)
        {
            SanPham sp = db.SanPhams.Find(ma);
            db.SanPhams.Remove(sp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
