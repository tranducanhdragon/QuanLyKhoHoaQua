using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HoaTuoi.Models.DAO;
using HoaTuoi.Models.EF;

namespace HoaTuoi.Controllers
{
    public class NhapHangController : LoginController
    {
        // GET: NhapHang
        public ActionResult Index()
        {
            var pn = new PhieuNhapHangDAO().GetListPhieuNhap();
            return View(pn);
        }

        // GET: NhapHang/Create
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.ddloai = new SelectList(new PhieuNhapHangDAO().GetLoaiQuaList(), "id_loai", "ten_loai");
            return View();
        }

        // POST: NhapHang/Create
        [HttpPost]
        public ActionResult Create(PhieuNhapHang pn)
        {
            try
            {
                // TODO: Add insert logic here                
                new PhieuNhapHangDAO().InsertPhieuNhap(pn);
                new PhieuNhapHangDAO().InsertToQua(pn);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Index");
            }
        }

        // GET: NhapHang/Edit/5
        public ActionResult Edit(int id)
        {
            var pn = new PhieuNhapHangDAO().GetPhieuNhapByID(id.ToString());
            return View(pn);
        }

        // POST: NhapHang/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, PhieuNhapHang pn)
        {
            try
            {
                // TODO: Add update logic here
                pn.id_phieu_nhap_hang = id.ToString();
                new PhieuNhapHangDAO().UpdatePhieuNhap(pn);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
