using QLDT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLDT.Controllers
{
    public class HeDieuHanhController : Controller
    {
        // GET: HeDieuHanh
        QL_DTEntities db = new QL_DTEntities();
        public ActionResult HeDieuHanhPartial()
        {
            var HSX = db.HeDieuHanhs.Take(6).ToList();
            return View(HSX);
        }
        public ViewResult DtTheoHDH(int MaHDH)
        {
            var ListHSX = db.SanPhams.Where(s => s.MaHDH == MaHDH).OrderBy(s => s.GiaTien).ToList();
            if (ListHSX.Count == 0)
            {
                ViewBag.Sach = "Không có NXB nào thuộc chủ đề này !";
            }
            return View(ListHSX);
        }
    }
}