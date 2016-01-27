using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TourSite2.Models;
using System.Net.Mail;
using System.IO;
using DataLayer;
using System.Threading.Tasks;

namespace TourSite2.Controllers
{
    public class SubscribeController : Controller
    {
        //
        // GET: /Subscribe/

        public ActionResult Sub()
        {
            return View();
        }
        //[HttpPost]

        //public ActionResult Sub(SubModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        MailAddress from = new MailAddress("bestpresentkh@mail.ru");
        //        MailAddress to = new MailAddress(model.Email);
        //        MailAddress To = new MailAddress("nata_bar@list.ru");
        //        MailMessage message1 = new MailMessage(from, to);
        //        MailMessage message2 = new MailMessage(from, To);
        //        message1.Subject = "Информация о подписке";
        //        message1.Body = "Здравствуйте, " + model.Name + "\r\n" + "Ваш Номер телефона:  " + model.Phone + "\r\n" + "Эл .почта" + model.Email + "\r\n" + "Спасибо, что подписались на наш сайт! " + "\r\n" + "\r\n" + "\r\n" + "С уважением  и благодарностью сотрудники ТА Лучший подарок" + "\r\n" + "г. Харьков, Полтавский шлях 123, 2 этаж, офис №6" + "\r\n" + "тел. (057) 297-60-97" + "\r\n" + "моб. 066-626-00-76" + "\r\n" + "068-922-70-76";



        //        message2.Subject = "Новая подписка";
        //        message2.Body = "Имя клиента:  " + model.Name + "\r\n" + "Номер телефона:  " + model.Phone + "\r\n" + "Эл .почта" + model.Email;

        //        SmtpClient client = new SmtpClient();
        //        client.Host = "smtp.mail.ru";
        //        client.Credentials = new System.Net.NetworkCredential("bestpresentkh@mail.ru", "nata2507");
        //        client.EnableSsl = true;

        //        try
        //        {
        //            Task.Factory.StartNew((Action)(() =>
        //            {
        //                client.Send(message1);
        //                client.Send(message2);
        //            }), TaskCreationOptions.AttachedToParent | TaskCreationOptions.LongRunning);
        //        }

        //        catch (SmtpFailedRecipientsException ex)
        //        {
        //            for (int i = 0; i < ex.InnerExceptions.Length; i++)
        //            {
        //                SmtpStatusCode status = ex.InnerExceptions[i].StatusCode;
        //                if (status == SmtpStatusCode.MailboxBusy ||
        //                    status == SmtpStatusCode.MailboxUnavailable)
        //                {
        //                    Console.WriteLine("Delivery failed - retrying in 5 seconds.");
        //                    System.Threading.Thread.Sleep(5000);
        //                    client.Send(message1);
        //                }
        //                else
        //                {
        //                    Console.WriteLine("Failed to deliver message to {0}",
        //                        ex.InnerExceptions[i].FailedRecipient);
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine("Exception caught in RetryIfBusy(): {0}",
        //                    ex.ToString());
        //        }
        //        return RedirectToAction("SubMail");
        //    }
        //    else
        //    {
        //        return View(model);
        //    }
            
        //}
        public ActionResult SubMail()
        {

            return View();
        }
        [HttpPost]
        public ActionResult SendEmail(object sender, EventArgs e, SubModel model)
        {
            string body = this.PopulateBody(model.Name,
                "Fetch multiple values as Key Value pair in ASP.Net AJAX AutoCompleteExtender",
                "http://www.bestprezent.com" +
                "in-ASP.Net-AJAX-AutoCompleteExtender.aspx",
                "Here Mudassar Ahmed Khan has explained how to fetch multiple column values i.e." +
                " ID and Text values in the ASP.Net AJAX Control Toolkit AutocompleteExtender"
                + "and also how to fetch the select text and value server side on postback");
            this.SendHtmlFormattedEmail(model.Email, "Спасибо за подписку!", body);

            return RedirectToAction("SubMail");
        }

        private string PopulateBody(string userName, string title, string url, string description)
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(Server.MapPath("~/EmailTemplate.cshtml")))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("{UserName}", userName);
            body = body.Replace("{Title}", title);
            body = body.Replace("{Url}", url);
            body = body.Replace("{Description}", description);
            return body;
        }

        private void SendHtmlFormattedEmail(string recepientEmail, string subject, string body)
        {
            using (MailMessage mailMessage = new MailMessage())
            {
                mailMessage.From = new MailAddress("info@bestprezent.com.ua");
                mailMessage.Subject = subject;
                mailMessage.Body = body;
                mailMessage.IsBodyHtml = true;
                mailMessage.To.Add(new MailAddress(recepientEmail));
                mailMessage.To.Add("nata_bar@list.ru");
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp-5.1gb.ua";
                smtp.EnableSsl = false;
                System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                NetworkCred.UserName = "u77204";
                NetworkCred.Password = "2507nata";
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                //smtp.Port = int.Parse(ConfigurationManager.AppSettings["Port"]);
                smtp.Send(mailMessage);
            }
        }
    }


}

