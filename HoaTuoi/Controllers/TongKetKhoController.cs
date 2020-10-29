using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HoaTuoi.Models.DAO;
using HoaTuoi.Models.EF;

namespace HoaTuoi.Controllers
{
    public class TongKetKhoController : LoginController
    {
        // GET: TongKetKho
        public ActionResult Index()
        {
            var tkd = new TongKetKhoDAO().GetTongKetLoaiQua();
            return View(tkd);
        }
    }
}