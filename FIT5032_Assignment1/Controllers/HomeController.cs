using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FIT5032_Week08A.Models;
using SendGrid.Helpers.Mail;
using System.IO;
using FIT5032_Assignment1.Email;

namespace FIT5032_Assignment1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Homepage()
        {
            return View();
        }

        public ActionResult Hotel()
        {
            return View();
        }

        public ActionResult Detail()
        {
            return View();
        }

        public ActionResult Info()
        {
            return View();
        }

        public ActionResult Send_Email()
        {
            return View(new SendEmailViewModel());
        }

        [HttpPost]
        public ActionResult Send_Email(SendEmailViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    String toEmail = model.ToEmail;
                    String subject = model.Subject;
                    String contents = model.Contents;
                    String fileName = "";
                    if (model.Upload.ContentLength > 0)
                    {
                        string serverPath = Server.MapPath("~/Uploads/");
                        string filePath = Path.GetExtension(model.Upload.FileName);
                        var myUniqueFileName = string.Format(@"{0}", Guid.NewGuid());
                        model.Upload.SaveAs(serverPath + myUniqueFileName + filePath);
                        fileName = serverPath + myUniqueFileName + filePath;
                    }

                    EmailSender es = new EmailSender();
                    es.Send(toEmail, subject,contents, fileName);

                    ViewBag.Result = "Email has been send.";

                    ModelState.Clear();

                    return View(new SendEmailViewModel());
                }
                catch
                {
                    return View();
                }
            }

            return View();
        }

        public ActionResult Chat()
        {
            return View();
        }

    }
}