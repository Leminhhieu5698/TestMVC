using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication19.Models;

namespace WebApplication19.Controllers
{
    public class HomeController : Controller
    {
        DataClasses2DataContext db = new DataClasses2DataContext();
        // GET: Home
        public ActionResult Index()
        {
            var all = from a in db.Saches
                      select a;
            return View(all);
        }
        public ActionResult Details(int id)
        {
            var all = from a in db.Saches
                      where a.masach == id
                      select a;
            return View(all);
        }
        
        public ActionResult Create()
        {
            //ViewBag.Loai = new SelectList(db.LOAISACHes, "maloai", "tenloai");
                ViewData["mal"] = new SelectList(db.LOAISACHes, "maloai", "tenloai");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection col,Sach s)
        {
            var ma = col["ma"];
            var tieu = col["tieu"];
            var tom = col["tom"];
            var noi = col["noi"];
            var tac = col["tac"];
            var gia = col["gia"];
            var hinh = col["hinh"];
            var mal = col["mal"];
            
               
                if (String.IsNullOrEmpty(tieu))
                {
                    ViewData["Loi2"] = "Hay nhap tieu de";
                }
                else if(tieu.Length < 5)
                {
                    ViewData["Loi2"] = "it nhat 5 ki tu";
                }

                if (String.IsNullOrEmpty(tom))
                {
                    ViewData["Loi3"] = "Hay nhap tom tat";
                }
                if (String.IsNullOrEmpty(noi))
                {
                    ViewData["Loi4"] = "Nhap noi dung";
                }
                if (String.IsNullOrEmpty(tac))
                {
                    ViewData["Loi5"] = "Nhap tac gia";
                }
                if (String.IsNullOrEmpty(gia))
                {
                    ViewData["Loi6"] = "Nhap gia";
                }
                if (String.IsNullOrEmpty(hinh))
                {
                    ViewData["Loi7"] = "Nhap hinh";
                }
               
                else
                {
                    s.tieude = tieu;
                    s.tomtat = tom;
                    s.noidung = noi;
                    s.tacgia = tac;
                    s.giasach = gia;
                    s.hinhanh = hinh;
                    s.maloai = mal;
                    db.Saches.InsertOnSubmit(s);
                    db.SubmitChanges();
                    //ViewBag.Loai = new SelectList(db.LOAISACHes, "maloai", "tenloai", s.maloai);
                    //    ViewData["mal"] = new SelectList(db.LOAISACHes, "maloai", "tenloai");

                    return RedirectToAction("Index");
                
            }
            return this.Create();
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
        public ActionResult Edit(int id)
        {
            var all = db.Saches.First(n => n.masach == id);
            var the = from a in db.LOAISACHes
                      select a;
            ViewData["mal"] = new SelectList(db.LOAISACHes, "maloai", "tenloai");

            return View(all);
        }
        [HttpPost]
        public ActionResult Edit(int id,FormCollection col)
        {
            var a = db.Saches.First(n=>n.masach==id);
            var ma = col["ma"];
            var tieu = col["tieu"];
            var tom = col["tom"];
            var noi = col["noi"];
            var tac = col["tac"];
            var gia = col["gia"];
            var hinh = col["hinh"];
            var mal = col["mal"];
            
            if (String.IsNullOrEmpty(ma))
            {
                ViewData["Loi1"] = "Hay nhap ma";
            }
            if (String.IsNullOrEmpty(tieu))
            {
                ViewData["Loi2"] = "Hay nhap tieu de";
            }
            if (String.IsNullOrEmpty(tom))
            {
                ViewData["Loi3"] = "Hay nhap tom tat";
            }
            if (String.IsNullOrEmpty(noi))
            {
                ViewData["Loi4"] = "Nhap noi dung";
            }
            if (String.IsNullOrEmpty(tac))
            {
                ViewData["Loi5"] = "Nhap tac gia";
            }
            if (String.IsNullOrEmpty(gia))
            {
                ViewData["Loi6"] = "Nhap gia";
            }
            if (String.IsNullOrEmpty(hinh))
            {
                ViewData["Loi7"] = "Nhap hinh";
            }
            if (String.IsNullOrEmpty(mal))
            {

            }
            else
            {
                a.tieude = tieu;
                a.giasach = gia;
                a.hinhanh = hinh;
                a.maloai = mal;
                a.noidung = noi;
                a.tacgia = tac;
                a.tomtat = tom;
                UpdateModel(a);
                db.SubmitChanges();
                return RedirectToAction("Index");

            }

            return this.Edit(id);
        }
        public ActionResult Delete(int id)
        {
            var all =db.Saches.First(m => m.masach == id);
            return View(all);
        }
        [HttpPost]
        public ActionResult Delete(int id,FormCollection col)
        {
            var all = db.Saches.Where(m => m.masach == id).First();
            db.Saches.DeleteOnSubmit(all);
            db.SubmitChanges();
            return RedirectToAction("Index");
        }
    }
}