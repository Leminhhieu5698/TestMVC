//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ThuHuong_Test.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Web;
    
    public partial class Sach
    {
        public string maSach { get; set; }
        public string tieuDe { get; set; }
        public string maLoai { get; set; }
        public string hinhAnh { get; set; }
    
        public virtual LoaiSach LoaiSach { get; set; }
        public HttpPostedFileBase hinhAnhFile { get; set; }
    }
}
