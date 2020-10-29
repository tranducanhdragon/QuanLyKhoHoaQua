using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HoaTuoi.Models.EF;
using HoaTuoi.Models.DAO;

namespace HoaTuoi.Controllers
{
    public class TaiKhoanController : Controller
    {
        // GET: TaiKhoan
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(TaiKhoan modelLogin)
        {
            if (modelLogin.userName != null && modelLogin.passWord != null)
            {
                TaiKhoanDAO dao = new TaiKhoanDAO();
                var result = dao.Login(modelLogin.userName, modelLogin.passWord);
                //Kiểm tra tài khoản đó nếu đúng thì tạo session cho user này
                if (result)
                {
                    var user = dao.TaiKhoanByUserName(modelLogin.userName);
                    Session.Add("TaiKhoanSession", user);
                    return RedirectToAction("Index", "NhapHang");
                }
                else
                {
                    return RedirectToAction("Login", "TaiKhoan");
                }
            }
            return View("Index");
        }
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(TaiKhoan user)
        {
            var dao = new TaiKhoanDAO();
            //dao.TaiKhoanInsert(user);
            return RedirectToAction("Index", "Home");
        }
        public ActionResult EndSession()
        {
            Session["TaiKhoanSession"] = null;
            return RedirectToAction("Login", "TaiKhoan");
        }
    }
}