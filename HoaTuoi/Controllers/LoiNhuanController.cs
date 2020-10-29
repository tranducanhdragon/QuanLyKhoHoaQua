using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HoaTuoi.Models.DAO;
using HoaTuoi.Models.EF;

namespace HoaTuoi.Controllers
{
    public class LoiNhuanController : LoginController
    {
        // GET: LoiNhuan
        public ActionResult Index()
        {
            var ln = new LoiNhuanDAO().GetLoiNhuanLoaiQua();
            return View(ln);
        }
        public ActionResult LoiNhuanLoaiQua()
        {
            var ln = new LoiNhuanDAO().GetLoiNhuanLoaiQua();
            
            return PartialView("LoiNhuanLoaiQua", ln);
        }
    }
}