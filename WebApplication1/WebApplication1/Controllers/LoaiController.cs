using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{
    public class LoaiController : Controller
    {
        Thicuoiki_WebEntities2 db = new Thicuoiki_WebEntities2();
        // GET: Loai
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult Loaipartial()
        {
            List<LoaiSP> sp = db.LoaiSPs.ToList<LoaiSP>();
            return PartialView(sp);
        }
        public ActionResult Sanphaminloai(string ma)
        {
            LoaiSP sp = db.LoaiSPs.Find(ma);
            if(sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<SanPham> lsp = db.SanPhams.Where(m => m.maLoai == ma).ToList<SanPham>();
            if (lsp.Count == 0)
            {
                ViewBag.Sp = "Không có sản phẩm nào";
            }
            else
                ViewBag.Sp = sp.tenLoai;
            return View(lsp);

        }
    }
}