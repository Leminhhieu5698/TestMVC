using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication19.Models;
namespace WebApplication19.Models
{
    public class GioHang
    {
        DataClasses2DataContext db = new DataClasses2DataContext();
        public string xtieude { get; set; }
        public int xmasach { get; set; }
        public string xtomtat { get; set; }
        public string xnoidung { get; set; }
        public string xtacgia { get; set; }
        public string xhinhanh { get; set; }
        public int xSL { get; set; }
        public double xgiasach { get; set; }
        public double xTT { get { return xSL * xgiasach; } }
        public GioHang(int id)
        {
            xmasach = id;
            Sach s = db.Saches.Single(n => n.masach == id);
            xtieude = s.tieude;
            xtomtat = s.tomtat;
            xnoidung = s.noidung;
            xtacgia = s.tacgia;
            xhinhanh = s.hinhanh;
            xgiasach = double.Parse(s.giasach);
            xSL = 1;
        }
    }
}
