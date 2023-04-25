using Quanlykhohang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quanlykhohang.Controllers
{
    public class ChitietphieunhapController : Controller
    {
        quanlykhoEntities db = new quanlykhoEntities();
        // GET: Chitietphieunhap
        public ActionResult ds_vattunhap()

        {
            List<chitiet_nhapkho> layds = new List<chitiet_nhapkho>();
            layds = db.chitiet_nhapkho.ToList();

            return Json(new
            {
                data = layds,
                totalItem = layds.Count,
                status = 200,
                messege = "Lấy dữ liệu thành công",
            }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult luu_vattunhap(string ma_phieu, string get_vattu, string soluong)
        {
            chitiet_nhapkho layds = new chitiet_nhapkho();
            layds.ma_phieu = ma_phieu;
            layds.ma_vattu = get_vattu;
            layds.sl_vattu = soluong;
            layds.ghichu = "Xuất thẳng";
            db.chitiet_nhapkho.Add(layds);
            db.SaveChanges();
            return Json(new
            {
                data = layds,
                status = 200,
                messege = "Lưu dữ liệu thành công",
            }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult sua_vattunhap(int id)
        {
            chitiet_nhapkho layds = new chitiet_nhapkho();
            layds = db.chitiet_nhapkho.FirstOrDefault(m => m.id == id);
            return Json(new
            {
                data = layds,
                status = 200,
                messege = "Lưu dữ liệu thành công",
            }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult capnhat_vattunhap(int id,string ma_phieu, string get_vattu, string soluong)
        {
            chitiet_nhapkho layds = new chitiet_nhapkho();        
            layds = db.chitiet_nhapkho.FirstOrDefault(m => m.id == id);
            layds.ma_phieu = ma_phieu;
            layds.ma_vattu = get_vattu;
            layds.sl_vattu = soluong;
            layds.ghichu = "Xuất thẳng";
            //db.chitiet_nhapkho.Add(layds);
            db.SaveChanges();
            return Json(new
            {
                data = layds,
                status = 200,
                messege = "Lưu dữ liệu thành công",
            }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult xoa_vattunhap(int id)
        {
          
            chitiet_nhapkho layds = new chitiet_nhapkho();
            layds = db.chitiet_nhapkho.FirstOrDefault(m => m.id == id);
            db.chitiet_nhapkho.Remove(layds);
            db.SaveChanges();
            return Json(new
            {
                data = layds,
                status = 200,
                messege = "Xóa dữ liệu thành công",
            }, JsonRequestBehavior.AllowGet);

        }
    }
}
