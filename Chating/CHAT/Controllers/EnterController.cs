using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CHAT.Models;
using CHAT.ViewModels;


namespace CHAT.Controllers
{
    public class EnterController : Controller
    {
        ChatModsContext db = new ChatModsContext();
        // GET: Enter
        public ActionResult EditProfile()
        {
            int ProfileId = Convert.ToInt32(Session["HumanId"]);
            if (ProfileId == 0)
            {
                return RedirectToAction("LogON","Enter");
            }
            else
            {
                return View(db.chaters.Find(ProfileId));
            }


        }
        [HttpPost]
        public ActionResult UpdateFhoto(ImageViewModel imageViewModel)
        {
            int UsId = Convert.ToInt32(Session["Humanid"]);
            if (UsId == 0)
            {
                return RedirectToAction("LogON", "Enter");
            }
            else
            {
                var File = imageViewModel.Photo;
                Chater s = db.chaters.Find(UsId);
                if (File != null)
                {
                    var fileExtention = System.IO.Path.GetExtension(File.FileName);
                    string id_extention = UsId + fileExtention;
                    string ImgPath = "~/ProfilePhotos/" + id_extention;
                    s.ImageLink = ImgPath;
                    db.Entry(s).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    var path = Server.MapPath("~/ProfilePhotos/");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    if ((System.IO.File.Exists(path + id_extention)))
                    {
                        System.IO.File.Delete(path + id_extention);
                    }
                    File.SaveAs((path + id_extention));
                   

                }
                return RedirectToAction("EditProfile","Enter");
            }
        }



       
        [HttpGet]
        public ActionResult RegistChater()
        {
            Session["HumanId"] = 0;
            return View();
        }
        [HttpPost]
        public ActionResult RegistChater(ChaterViewModel chaterViewModel)
        {
           bool ChaterNameExists = db.chaters.Any(x => x.ChaterkName == chaterViewModel.ChaterkName);
            if (ChaterNameExists)
            {
                ViewBag.NameAlert = "Это имя уже кем то используется";
                return View();
            }
            bool MailExists = db.chaters.Any(x => x.Email == chaterViewModel.Email);
            if (MailExists)
            {
                ViewBag.MailAlert = "Эта почта уже используется";
                return View();
            }
            Chater chater = new Chater();
            chater.ChaterkName = chaterViewModel.ChaterkName;
            chater.Email = chaterViewModel.Email;
            chater.Pass = chaterViewModel.Pass;
            chater.ImageLink = "";
            chater.DateRegistered = DateTime.Now;
            db.chaters.Add(chater);
            db.SaveChanges();
            return RedirectToAction("LogON", "Enter");

        }

        [HttpGet]
        public ActionResult LogON()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LogON(LogONViewModel logONViewModel)
        {
            bool VerifyAccount = db.chaters.Any(x => x.ChaterkName == logONViewModel.ChaterkName && x.Pass == logONViewModel.Pass);
            if (VerifyAccount)
            {
                Session["HumanId"] = db.chaters.Single(p => p.ChaterkName == logONViewModel.ChaterkName).Id;
                Session["IMG"] = db.chaters.Single(y => y.ChaterkName == logONViewModel.ChaterkName).ImageLink;
                return RedirectToAction("MessagePost", "Chat");
            }
            else {
                ViewBag.Message = "Нерный логин или пароль";
                return View();
            }
  

        }
    }
}