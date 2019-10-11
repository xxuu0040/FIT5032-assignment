using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using FIT5032_Week08A.Models;

namespace FIT5032_Assignment1.Email
{
    public class EmailSender
    {
        // Please use your API KEY here.
        private const String API_KEY = "";

        public void Send(String toEmail, String subject, String contents, String fileName)
        {
            var client = new SendGridClient(API_KEY);
            var from = new EmailAddress("noreply@localhost.com", "FIT5032 Example Email User");
            var to = new EmailAddress(toEmail, "");
            var plaint = contents;
            var htmlContent = "<p>" + contents + "</p>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plaint, htmlContent);
            if (fileName != "")
            {
                var bytes = File.ReadAllBytes(fileName);
                var file = Convert.ToBase64String(bytes);
                msg.AddAttachment("file.txt", file);
            }
            var response = client.SendEmailAsync(msg);
        }

        public void SendWithAttach()
        {

        }

    }
}