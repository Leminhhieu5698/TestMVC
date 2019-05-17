using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class NguoiDungController : Controller
    {
        // GET: NguoiDung
        public ActionResult Index()
        {  
            return View();
        }
        public ActionResult DangNhap(string strURL,FormCollection f)
        {
            string username = f["txtUser"].ToString();
            string password = f["txtPass"].ToString();
            if(Check(username,password))
            {
                Session["maTaiKhoan"] = username;
                HttpCookie ck = new HttpCookie("MyCookies");
                ck["name"] = username;
                Response.Cookies.Add(ck);
                return Redirect(strURL);
            }
            ViewBag.TB = "Tên tài khoản hoặc mật khẩu không đúng";
            return Redirect(strURL);
        }
        public bool Check(string username,string password)
        {
            if (username == "Hieu" && password == "123")
            {
                return true;
            }
            return false;
        }
        public ActionResult DangXuat(string strURL)
        {
            Session.Abandon();
            if(Request.Cookies["MyCookies"] != null)
            {
                HttpCookie ck = new HttpCookie("MyCookies");
                ck.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(ck);
            }
            return Redirect(strURL);
        }
    }
}