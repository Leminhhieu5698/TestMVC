using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;
using System.Data;
namespace WebApplication1.Models
{
    public class MuaSP
    {
        Thicuoiki_WebEntities2 db = new Thicuoiki_WebEntities2();
        public string xmaSP { get; set; }
        public string xtenSP { get; set; }
        public string xnamSX { get; set; }
        public float xGiaSP { get; set; }
        public string xhinhAnh { get; set; }
        public int xSL { get; set; }
        public float xTT { get { return xGiaSP * xSL; } }
        public MuaSP(string ma)
        {
            xmaSP = ma;
            SanPham sp = db.SanPhams.Find(ma);
            xtenSP = sp.tenSP;
            xGiaSP = (float)sp.GiaSP;
            xSL = 1;
            xhinhAnh = sp.hinhAnh;

        }
    }
}