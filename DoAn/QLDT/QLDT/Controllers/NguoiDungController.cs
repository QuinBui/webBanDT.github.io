using QLDT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLDT.Controllers
{
    public class NguoiDungController : Controller
    {
        // GET: NguoiDung
        QL_DTEntities db = new QL_DTEntities();
        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangKy(TaiKhoan kh, FormCollection f)
        {
            var hoten = f["HotenKH"];
            var tendn = f["TenDN"];
            var matkhau = f["Matkhau"];
            var rematkhau = f["ReMatkhau"];
            var dienthoai = f["Dienthoai"];
            //var ngaysinh = String.Format("{0:MM/DD/YYYY}", f["NgaySinh"]);
            var email = f["Email"];
            var diachi = f["Diachi"];

            if (String.IsNullOrEmpty(hoten))
            {
                ViewData["Loi1"] = "Họ tên không được bỏ trống";
            }
            if (String.IsNullOrEmpty(tendn))
            {
                ViewData["Loi2"] = "Tên đăng nhập không được bỏ trống";
            }
            if (String.IsNullOrEmpty(matkhau))
            {
                ViewData["Loi3"] = "Vui lòng nhập mật khẩu";
            }
            if (String.IsNullOrEmpty(rematkhau))
            {
                ViewData["Loi4"] = "Vui lòng nhập mật khẩu";
            }
            if (String.IsNullOrEmpty(dienthoai))
            {
                ViewData["Loi5"] = "Vui lòng nhập số điện thoại";
            }
            if (!String.IsNullOrEmpty(hoten) && !String.IsNullOrEmpty(tendn) && !String.IsNullOrEmpty(matkhau) && !String.IsNullOrEmpty(rematkhau) && !String.IsNullOrEmpty(dienthoai))
            {
                kh.HoTen = hoten;
                kh.TenTK = tendn;
                kh.MatKhau = matkhau;
                kh.DiaChi = diachi;
                kh.Email = email;
                kh.lv = 2;

                db.TaiKhoans.Add(kh);
                db.SaveChanges();
                return RedirectToAction("DangNhap", "NguoiDung");
            }
            return View();
        }
        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(FormCollection f)
        {
            var tendn = f["TenDN"];
            var matkhau = f["Matkhau"];
            if (String.IsNullOrEmpty(tendn))
            {
                ViewData["Loi1"] = "Họ tên không được bỏ trống";
            }
            if (String.IsNullOrEmpty(matkhau))
            {
                ViewData["Loi2"] = "Vui lòng nhập mật khẩu";
            }
            if (!String.IsNullOrEmpty(tendn) && !String.IsNullOrEmpty(matkhau))
            {
                TaiKhoan kh = db.TaiKhoans.SingleOrDefault(c => c.TenTK == tendn && c.MatKhau == matkhau);
                if (kh != null && kh.TenTK == "admin" && kh.MatKhau == "123")
                {
                    return RedirectToAction("SanPham_Show", "QuanLy");
                }
                else if (kh != null)
                {
                    return RedirectToAction("DienThoai_Partial", "SanPham");
                }
                else
                {
                    ViewData["Loi3"] = "Bạn nhập sai tên hoặc mật khẩu rồi :(";
                    //return RedirectToAction("DangKy", "NguoiDung");
                }
            }
            return View();
        }
    }
}