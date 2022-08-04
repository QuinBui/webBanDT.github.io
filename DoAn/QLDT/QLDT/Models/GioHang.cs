using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace QLDT.Models
{
    public class GioHang
    {
        QL_DTEntities db = new QL_DTEntities();
        public int iMaSach { get; set; }
        public string sTenSach { set; get; }
        public string sAanhBia { set; get; }
        public double dDonGia { set; get; }
        public int iSoLuong { set; get; }
        public double dThanhTien
        {
            get { return iSoLuong * dDonGia; }
        }
        //Khoi tao gio hang
        public GioHang(int MaSach)
        {
            iMaSach = MaSach;
            SanPham sp = db.SanPhams.Single(s => s.MaSP == iMaSach);
            sTenSach = sp.TenSP;
            sAanhBia = sp.AnhBia;
            dDonGia = double.Parse(sp.GiaTien.ToString());
            iSoLuong = 1;
        }
    }
}