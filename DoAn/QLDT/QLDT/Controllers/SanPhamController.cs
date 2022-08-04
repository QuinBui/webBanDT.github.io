using PagedList;
using QLDT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLDT.Controllers
{
    public class SanPhamController : Controller
    {
        // GET: SanPham
        QL_DTEntities db = new QL_DTEntities();
        SanPhamAPIController sp_api = new SanPhamAPIController();
        public ActionResult DienThoai_Partial(int? page)
        {
            if (page == null)
                page = 1;

            var lNXB = db.SanPhams.Take(35).ToList();

            int pageSize = 9;

            int pageNumber = (page ?? 1);
            return View(lNXB.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult XemChiTietAPI(int maSP)
        {
            SanPhamHSXMix SP = sp_api.getDetailSanPham(maSP);
            return View(SP);
        }
        public ActionResult XemChiTiet(int ms)
        {
            SanPham sp = db.SanPhams.Single(s => s.MaSP == ms);
            if (sp == null)
            {
                return HttpNotFound();
            }
            return View(sp);
        }
        public ActionResult TimKiem(string search)
        {
            var lstSearch = db.SanPhams.Where(t => t.MaSP.ToString().Contains(search) || t.TenSP.Contains(search)
                || t.GiaTien.ToString().Contains(search)
                || t.SoLuong.ToString().Contains(search) || t.MaHSX.ToString().Contains(search));
            return View(lstSearch.ToList());
        }
    }
}