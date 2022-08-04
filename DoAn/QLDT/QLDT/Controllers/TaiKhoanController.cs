using QLDT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLDT.Controllers
{
    public class TaiKhoanController : Controller
    {
        // GET: TaiKhoan
        QL_DTEntities db = new QL_DTEntities();
        public ActionResult checkTaiKhoan(String tk,String mk)
        {
            return View();
        }
    }
}