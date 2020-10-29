using HoaTuoi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HoaTuoi.Models.DAO;
using HoaTuoi.Models.EF;

namespace HoaTuoi.Controllers
{
    public class XuatHangController : LoginController
    {
        // GET: BanHang
        public ActionResult Index()
        {
            var px = new PhieuXuatHangDAO().GetListPhieuXuat();
            return View(px);
        }

        // GET: BanHang/Create
        public ActionResult Create()
        {
            ViewBag.ddloai = new SelectList(new PhieuXuatHangDAO().GetLoaiQuaList(), "id_loai", "ten_loai");
            return View();
        }

        // POST: BanHang/Create
        [HttpPost]
        public ActionResult Create(PhieuXuatHang px)
        {
            try
            {
                // TODO: Add insert logic here                
                new PhieuXuatHangDAO().InsertPhieuXuat(px);
                new PhieuXuatHangDAO().DeleteFromQua(px);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Index");
            }
        }

        // GET: BanHang/Edit/5
        public ActionResult Edit(int id)
        {
            var px = new PhieuXuatHangDAO().GetPhieuXuatByID(id.ToString());
            return View(px);
        }

        // POST: BanHang/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, PhieuXuatHang px)
        {
            try
            {
                // TODO: Add update logic here
                px.id_phieu_xuat_hang = id.ToString();
                new PhieuXuatHangDAO().UpdatePhieuXuat(px);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}
