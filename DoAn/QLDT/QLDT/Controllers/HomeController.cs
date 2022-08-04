using QLDT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLDT.Controllers
{
    public class HomeController : Controller
    {
        QL_DTEntities db = new QL_DTEntities();
        public ActionResult TrangChu()
        {
            return View();
        }

        public ActionResult QC()
        {
            return View();
        }
        public ActionResult QCip()
        {
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LienHe()
        {
            return View();
        }
        //[HttpPost]
        public ActionResult PhanHoi(PhanHoi hss)
        {
            if (ModelState.IsValid)
            {
                db.PhanHois.Add(hss);
                db.SaveChanges();
                return RedirectToAction("DangKy", "NguoiDung");
            }
            return View(hss);
        }
    }
}