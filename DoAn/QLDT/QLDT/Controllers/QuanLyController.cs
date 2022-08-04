using PagedList;
using QLDT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLDT.Controllers
{
    public class QuanLyController : Controller
    {
        // GET: QuanLy
        QL_DTEntities db = new QL_DTEntities();
        public ActionResult HangSanXuat_Show()
        {
            return View(db.HangSanXuats.ToList());
        }
        public ActionResult HangSanXuat_Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult HangSanXuat_Create(HangSanXuat hss)
        {
            if (ModelState.IsValid)
            {
                db.HangSanXuats.Add(hss);
                db.SaveChanges();
                return RedirectToAction("HangSanXuat_Show", "QuanLy");
            }
            return View(hss);
        }
        
        //Update
        public ActionResult HangSanXuat_Update(int id = 0)
        {
            HangSanXuat dept = db.HangSanXuats.Single(d => d.MaHSX == id);
            if (dept == null)
            {
                return HttpNotFound();
            }
            return View(dept);
        }
        [HttpPost]
        public ActionResult HangSanXuat_Update(HangSanXuat dept)
        {
            if (ModelState.IsValid)
            {
                db.HangSanXuats.Attach(dept);
                db.Entry(dept).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("HangSanXuat_Show", "QuanLy");
            }
            return View(dept);
        }

        //Delete
        public ActionResult HangSanXuat_Delete(int id = 0)
        {
            HangSanXuat empl = db.HangSanXuats.Single(d => d.MaHSX == id);
            if (empl == null)
            {
                return HttpNotFound();
            }
            return View(empl);
        }
        [HttpPost, ActionName("HangSanXuat_Delete")]
        public ActionResult HangSanXuat_DeleteConfirm(int id = 0)
        {
            HangSanXuat empl = db.HangSanXuats.Single(d => d.MaHSX == id);
            if (empl == null)
            {
                return HttpNotFound();
            }
            db.Entry(empl).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("HangSanXuat_Show", "QuanLy");
        }

        //SAN PHAM -------------------
        
        public ActionResult SanPham_Show(int? page)
        {
            if (page == null)
                page = 1;

            var lNXB = db.SanPhams.ToList();

            int pageSize = 9;

            int pageNumber = (page ?? 1);
            return View(lNXB.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult SanPham_Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SanPham_Create(SanPham sp)
        {
            if (ModelState.IsValid)
            {
                db.SanPhams.Add(sp);
                db.SaveChanges();
                return RedirectToAction("SanPham_Show", "QuanLy");
            }
            return View(sp);
        }
        //Update
        public ActionResult SanPham_Update(int id = 0)
        {
            SanPham dept = db.SanPhams.Single(d => d.MaSP == id);
            if (dept == null)
            {
                return HttpNotFound();
            }
            return View(dept);
        }
        [HttpPost]
        public ActionResult SanPham_Update(SanPham dept)
        {
            if (ModelState.IsValid)
            {
                db.SanPhams.Attach(dept);
                db.Entry(dept).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("SanPham_Show", "QuanLy");
            }
            return View(dept);
        }
        //Delete
        public ActionResult SanPham_Delete(int id = 0)
        {
            SanPham empl = db.SanPhams.Single(d => d.MaSP == id);
            if (empl == null)
            {
                return HttpNotFound();
            }
            return View(empl);
        }
        [HttpPost, ActionName("SanPham_Delete")]
        public ActionResult SanPham_DeleteConfirm(int id = 0)
        {
            SanPham empl = db.SanPhams.Single(d => d.MaSP == id);
            if (empl == null)
            {
                return HttpNotFound();
            }
            db.Entry(empl).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("SanPham_Show", "QuanLy");
        }

        //Lấy dữ liệu từ HoaDon & CTHD
        public ActionResult CTHD_HoaDon_Show()
        {
            //var listED = db.ChiTietDHs.Include("DonHang").ToList();
            return View(db.ChiTietDHs.ToList());
        }
        public ActionResult KhachHang_Show()
        {
            return View(db.TaiKhoans.ToList());
        }

        public ActionResult TimKiem()
        {
            return View();
        }
    }
}