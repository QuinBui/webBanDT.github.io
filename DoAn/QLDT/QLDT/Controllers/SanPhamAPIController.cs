using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using QLDT.Models;

namespace QLDT.Controllers
{
    public class SanPhamAPIController : ApiController
    {
        // GET: SanPhamAPI
        QL_DTEntities db = new QL_DTEntities();
        public List<SanPham> getSanPham()
        {
            var lstSP = db.SanPhams.Take(8).OrderBy(t => t.MaSP).ToList();
            return lstSP;
        }
        public SanPhamHSXMix getDetailSanPham(int maSP)
        {
            var SP = from sp in db.SanPhams
                     join l in db.HangSanXuats
                     on sp.MaHSX equals l.MaHSX
                     where sp.MaSP == maSP
                     select new SanPhamHSXMix()
                     {
                         MaSP = sp.MaSP,
                         TenSP = sp.TenSP,
                         HangSX = l.TenHang,
                         MoTa = sp.MoTa,
                         GiaBan = int.Parse(sp.GiaTien.ToString()),
                         SoLuong = int.Parse(sp.SoLuong.ToString()),
                         Anh = sp.AnhBia
                     };
            return SP.FirstOrDefault(e => e.MaSP == maSP);
        }
    }
}