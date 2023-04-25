using Microsoft.Ajax.Utilities;
using PagedList;
using Quanlykhohang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace Quanlykhohang.Controllers
{
    public class PhieunhapkhoController : Controller
    {
        quanlykhoEntities db = new quanlykhoEntities();
        // GET: Phieunhapkho
        public ActionResult Index(int? page, int? pageSize)
        {
            if (page == null)
            {
                page = 1;
            }
            if (pageSize == null)
            {
                pageSize = 5;
            }
            List<nhapkho> layds = new List<nhapkho>();
            layds = db.nhapkhoes.ToList();

            return View(layds.ToPagedList((int)page, (int)pageSize));
        }
        public ActionResult phieunhapkho()

        {
            //Tạo mã phiếu:
            var todayDate = DateTime.Now;// hàm nhận ngày giờ hiện tại
            string strToday = todayDate.ToString("yyMMddHH"); // converts date to string as per current culture         
            ViewBag.ma_phieu = "PNK "+strToday; //nối chuổi và biến
            //Tao list ds nhanvien
            List<nhanvien> get_nhanvien = new List<nhanvien>();
            get_nhanvien = db.nhanviens.ToList();
            //Add vào selectlist
            SelectList ds_nhanvien = new SelectList(get_nhanvien, "hoten_nv", "hoten_nv");
            ViewBag.ds_nhanvien = ds_nhanvien;

            //Tao list ds kho
            List<kho> get_kho = new List<kho>();
            get_kho = db.khoes.ToList();
            //Add vào selectlist
            SelectList ds_kho = new SelectList(get_kho, "ten_kho", "ten_kho");
            ViewBag.ds_kho = ds_kho;

            //Tao list ds vattu
            List<vattu> get_vattu = new List<vattu>();
            get_vattu = db.vattus.ToList();
            //Add vào selectlist
            SelectList ds_vattu = new SelectList(get_vattu, "ten_vt", "ten_vt");
            ViewBag.ds_vattu = ds_vattu;

            //Tao list ds donvitinh
            List<donvitinh> get_dvt = new List<donvitinh>();
            get_dvt = db.donvitinhs.ToList();
            //Add vào selectlist
            SelectList ds_dvt = new SelectList(get_dvt, "ten_dvt", "ten_dvt");
            ViewBag.ds_dvt = ds_dvt;

            return View();
        }

        public ActionResult luu_phieunhap(string get_nhanvien, string get_kho,string txt_ma_phieu, nhapkho nk)
        {
            if (ModelState.IsValid)
            {
               
                nhapkho layds = new nhapkho();
                layds.ma_phieu = txt_ma_phieu;
                layds.ngay_nhap = nk.ngay_nhap;
                layds.ma_nv = get_nhanvien;
                layds.ma_kho = get_kho;
                layds.lydo = "123";
                db.nhapkhoes.Add(layds);

                try
                {
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return View(e);
                }
                return RedirectToAction("Index");
            }

            else
            {
                return View();
            }

        }
        public ActionResult sua_phieunhap(int id)
        {
            //Tao list ds nhanvien
            List<nhanvien> get_nhanvien = new List<nhanvien>();
            get_nhanvien = db.nhanviens.ToList();
            //Add vào selectlist
            SelectList ds_nhanvien = new SelectList(get_nhanvien, "hoten_nv", "hoten_nv");
            ViewBag.ds_nhanvien = ds_nhanvien;

            //Tao list ds kho
            List<kho> get_kho = new List<kho>();
            get_kho = db.khoes.ToList();
            //Add vào selectlist
            SelectList ds_kho = new SelectList(get_kho, "ten_kho", "ten_kho");
            ViewBag.ds_kho = ds_kho;
            nhapkho layds = new nhapkho();
            layds = db.nhapkhoes.FirstOrDefault(m => m.id == id);
            return View(layds);
        }

        [HttpPost]
        public ActionResult capnhat_phieunhap(int id,nhapkho nk)
        {
            if (ModelState.IsValid)
            {
                nhapkho layds = new nhapkho();           
                layds = db.nhapkhoes.FirstOrDefault(m => m.id == id);
                layds.ma_phieu = nk.ma_phieu;
                layds.ngay_nhap = nk.ngay_nhap;
                layds.ma_nv = nk.ma_nv;
                layds.ma_kho = nk.ma_kho;
                layds.lydo = "123";               

                try
                {
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return View(e);
                }
                return RedirectToAction("Index");
            }

            else
            {
                return View();
            }
            
        }
        public ActionResult xoa_phieunhap(int id)
        {
         nhapkho ladys=new nhapkho();
            ladys= db.nhapkhoes.FirstOrDefault(l => l.id == id);
            db.nhapkhoes.Remove(ladys);
            db.SaveChanges();
            return RedirectToAction("Index");            
        }
      public ActionResult invoice() 
        {
            return View();

        }
    }
  
}

