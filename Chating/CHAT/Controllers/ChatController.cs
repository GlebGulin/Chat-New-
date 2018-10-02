using CHAT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using CHAT.ViewModels;

namespace CHAT.Controllers
{
    public class ChatController : Controller
    {
        ChatModsContext db = new ChatModsContext();
        // GET: Chat
        public ActionResult MessagePost()
        {
            var messages = db.messagers.Include(X => X.Answers).ToList();
            //var message = db.messagers.ToString();
            return View(messages);
        }
        [HttpPost]
        public ActionResult MessagePost(MessageViewModel messageViewModel)
        {
            int humanId = Convert.ToInt32(Session["HumanId"]);
            if (humanId == 0)
            {
                return RedirectToAction("LogON", "Enter");
            }
            else
            {
                try
                {
                    Messager messager = new Messager();
                    messager.Message = messageViewModel.Message;
                    messager.ChaterId = humanId;
                    messager.Published = DateTime.Now;
                    db.messagers.Add(messager);
                    db.SaveChanges();
                    return RedirectToAction("MessagePost");
                }
                catch (Exception ex)
                {

                    Response.StatusCode = 500;
                    return Content(ex.Message);
                }
            }

        }

        [HttpPost]
        public ActionResult PostAnswer(AnswerViewModel answerViewModel)
        {
            int humanId = Convert.ToInt32(Session["HumanId"]);
            if (humanId == 0)
            {
                return RedirectToAction("LogON", "Enter");
            }
            else
            {
                try
                {
                    Answer answer = new Answer();
                    answer.Message = answerViewModel.Message;
                    answer.MessagerId = answerViewModel.MessId;
                    answer.ChaterId = humanId;
                    answer.PostTime = DateTime.Now;
                    db.answers.Add(answer);
                    db.SaveChanges();
                    return RedirectToAction("MessagePost");
                }
                catch (Exception ex)
                {

                    Response.StatusCode = 500;
                    return Content(ex.Message);
                }
            }
            

        }
        [HttpGet]
        public ActionResult LogOUT()
        {
            Session["HumanId"] = 0;
            return RedirectToAction("LogON", "Enter");
        }
    }
}