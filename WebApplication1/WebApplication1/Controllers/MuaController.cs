using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{
    public class MuaController : Controller
    {
        // GET: Mua
        public ActionResult Index()
        {
            return View();
        }
        Thicuoiki_WebEntities2 db = new Thicuoiki_WebEntities2();
        // GET: Mua
        
        public ActionResult Datsanpham()
        {
            if (Session["Mua"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<MuaSP> ls = GetSP();
            ViewBag.Tien = ls.Sum(x => x.xTT);
            ViewBag.ThongBao = this.TempData["Thông Báo"];
            return View(ls);

        }
        public List<MuaSP> GetSP()
        {
            List<MuaSP> ls = Session["Mua"] as List<MuaSP>;
            if (ls == null)
            {
                ls = new List<MuaSP>();
                Session["Mua"] = ls;
            }
            return ls;
        }
        public ActionResult ThemSP(string ma, string strurl)
        {
            SanPham ls = db.SanPhams.Find(ma);
            if (ls == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<MuaSP> lsm = GetSP();
            //Kiểm tra xe có hay chưa
            MuaSP ms = lsm.Find(n => n.xmaSP == ma);
            if (ms == null)
            {
                ms = new MuaSP(ma);
                lsm.Add(ms);
                return Redirect(strurl);
            }
            else
            {
                ms.xSL++; // nếu ko thì cộng lên
            }
            return Redirect(strurl);
        }
        public int tongSL()
        {
            int tongsl = 0;
            List<MuaSP> lsm = Session["Mua"] as List<MuaSP>;
            if (lsm != null)
            {
                tongsl = lsm.Sum(n => n.xSL);

            }
            return tongsl;
        }
        public float tongtien()
        {
            float tongsl = 0;
            List<MuaSP> lsm = Session["Mua"] as List<MuaSP>;
            if (lsm != null)
            {
                tongsl = lsm.Sum(n => n.xSL);

            }
            return tongsl;
        }
        public ActionResult sanphammuaPartial()
        {
            if (tongSL() == 0)
            {
                return PartialView();
            }
            ViewBag.tongsl = tongSL();
            ViewBag.tongtt = tongtien();
            return PartialView();
        }
        public ActionResult Capnhat(string ma,FormCollection f)
        {
            SanPham sp = db.SanPhams.Find(ma);
            if(sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<MuaSP> lss = GetSP();
            MuaSP x = lss.FirstOrDefault(n => n.xmaSP == ma);
            if(x != null)
            {
                x.xSL = int.Parse(f["txtSoLuong"].ToString());
            }
            return RedirectToAction("Datsanpham");

        }
        public ActionResult Xoasanpham(string ma)
        {
            SanPham x = db.SanPhams.Find(ma);
            if(x == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<MuaSP> lsm = GetSP();
            MuaSP m = lsm.FirstOrDefault(n => n.xmaSP == ma);
            if(m != null)
            {
                lsm.RemoveAll(n => n.xmaSP == ma);
            }
            if(lsm.Count == 0)
            {
                return RedirectToAction("Index","Home");
            }
            return RedirectToAction("Datsanpham");
        }
    }
}