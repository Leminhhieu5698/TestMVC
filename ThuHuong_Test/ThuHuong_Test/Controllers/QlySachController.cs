using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThuHuong_Test.Models;

namespace ThuHuong_Test.Controllers
{
    public class QlySachController : Controller
    {
        ThuHuong_TestEntities db = new ThuHuong_TestEntities();
        // GET: QlySach
        public ActionResult Index()
        {
            return View(db.Saches.ToList<Sach>());
        }

        // GET: QlySach/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: QlySach/Create
        public ActionResult Create()
        {
            ViewBag.TenLSach = new SelectList(db.LoaiSaches, "maLoai", "maLoai");
            return View();
        }

        // POST: QlySach/Create
        [HttpPost]
        public ActionResult Create(Sach s)
        {
            if (s == null)
            {
                Response.StatusCode = 404;
                return View();
            }
            var fhinh = Request.Files["hinhAnhFile"];
            var path = Server.MapPath("~/HinhAnh/" + fhinh.FileName);
            fhinh.SaveAs(path);

            if (ModelState.IsValid)
            {
                s.hinhAnh = fhinh.FileName.ToString();
                db.Saches.Add(s);
                db.SaveChanges();
                return RedirectToAction("Index", "QlySach");
            }
            ViewBag.TenLSach = new SelectList(db.LoaiSaches, "maLoai", "maLoai", s.maLoai);
            return View(s);
        }

        // GET: QlySach/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: QlySach/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: QlySach/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: QlySach/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
