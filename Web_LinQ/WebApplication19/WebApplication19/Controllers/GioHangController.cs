using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication19.Models;
namespace WebApplication19.Controllers
{
    public class GioHangController : Controller
    {
        // GET: GioHang
        DataClasses2DataContext db = new DataClasses2DataContext();
        public ActionResult Index()
        {
            return View();
        }
        public List<GioHang> laygiohang()
        {
            List<GioHang> lst = Session["giohang"] as List<GioHang>;
            if (lst == null)
            {
                lst = new List<GioHang>();
                Session["giohang"] = lst;
            }
            return lst;
        }
        public ActionResult ThemGioHang(int id,string strUrl)
        {
            List<GioHang> lst = laygiohang();
            GioHang gh = lst.Find(n => n.xmasach == id);
            if (gh == null)
            {
                gh = new GioHang(id);
                lst.Add(gh);
                return Redirect(strUrl);
            }
            else
            {
                gh.xSL++;
                return Redirect(strUrl);
            }
            
        }
        private double TongThanhTien()
        {
            double xTTT = 0;
            List<GioHang> lst = Session["giohang"] as List<GioHang>;
            if (lst != null)
            {
                xTTT = lst.Sum(n => n.xTT);

            }
            return xTTT;
        }
        private int SoLuong()
        {
            int iSL = 0;
            List<GioHang> lst = Session["giohang"] as List<GioHang>;
            if (lst != null)
            {
                iSL = lst.Sum(n => n.xSL);
            }
            return iSL;
        }
        public ActionResult GioHangParti()
        {
            if (SoLuong()==0)
            {
                return PartialView();
            }
            ViewBag.TongThanhTien = TongThanhTien();
            ViewBag.SoLuong = SoLuong();
            return PartialView();
        }
        public ActionResult ShopGioHang()
        {
            List<GioHang> lst = Session["giohang"] as List<GioHang>;
            if (lst.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.TongThanhTien = lst.Sum(n => n.xTT);
            ViewBag.SoLuong = lst.Sum(n => n.xSL);
            return View(lst);
        }
        
    }
}