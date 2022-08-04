using QLDT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLDT.Controllers
{
    public class HangSanXuatController : Controller
    {
        // GET: HangSanXuat
        QL_DTEntities db = new QL_DTEntities();
        public ActionResult HangSanXuatPartial()
        {
            var HSX = db.HangSanXuats.Take(6).ToList();
            return View(HSX);
        }
        public ViewResult DtTheoHSX(int MaHSX)
        {
            var ListHSX = db.SanPhams.Where(s => s.MaHSX == MaHSX).OrderBy(s => s.GiaTien).ToList();
            if (ListHSX.Count == 0)
            {
                ViewBag.Sach = "Không có điện thoại nào thuộc hãng này !";
            }
            return View(ListHSX);
        }
    }
}