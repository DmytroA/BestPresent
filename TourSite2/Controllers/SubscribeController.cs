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


        [HttpGet]

        public ActionResult Sub()
        {
            var context = new TourEntities();
          
     
            return View();
        }
        [HttpPost]
        public ActionResult SubMail()
        {
            MailAddress from = new MailAddress("bestpresentkh@mail.ru");
            MailAddress to = new MailAddress(Request.Params["MailAdress"]);
            MailAddress To = new MailAddress("nata_bar@list.ru");
            MailMessage message1 = new MailMessage(from, to);
            MailMessage message2 = new MailMessage(from, To);
            message1.Subject = "Информация о подписке";
            message1.Body = "Здравствуйте, " + Request.Params["Name"] + "\r\n" + "Ваш Номер телефона:  " + Request.Params["Phone"] + "\r\n" + "Эл .почта" + Request.Params["MailAdress"] + "\r\n" + "Спасибо, что подписались на наш сайт! " + "\r\n" + "\r\n" + "\r\n" + "С уважением  и благодарностью сотрудники ТА Лучший подарок" + "\r\n" + "г. Харьков, Полтавский шлях 123, 2 этаж, офис №6" + "\r\n" + "тел. (057) 297-60-97" + "\r\n" + "моб. 066-626-00-76" + "\r\n" + "068-922-70-76";

 

            message2.Subject = "Новая подписка";
            message2.Body = "Имя клиента:  " + Request.Params["Name"] + "\r\n" + "Номер телефона:  " + Request.Params["Phone"] + "\r\n" + "Эл .почта" + Request.Params["MailAdress"]; 

            SmtpClient client = new SmtpClient();
            client.Host = "smtp.mail.ru";
            client.Credentials = new System.Net.NetworkCredential("bestpresentkh@mail.ru", "nata2507");
            client.EnableSsl = true;

            try
            {
                Task.Factory.StartNew((Action)(() =>
                {
                    client.Send(message1);
                    client.Send(message2);
                }), TaskCreationOptions.AttachedToParent | TaskCreationOptions.LongRunning);
            }

             catch (SmtpFailedRecipientsException ex)
			{
				for (int i = 0; i < ex.InnerExceptions.Length; i++)
				{
					SmtpStatusCode status = ex.InnerExceptions[i].StatusCode;
					if (status == SmtpStatusCode.MailboxBusy ||
						status == SmtpStatusCode.MailboxUnavailable)
					{
						Console.WriteLine("Delivery failed - retrying in 5 seconds.");
						System.Threading.Thread.Sleep(5000);
						client.Send(message1);
					}
					else
					{
						Console.WriteLine("Failed to deliver message to {0}", 
						    ex.InnerExceptions[i].FailedRecipient);
					}
				}
			}
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in RetryIfBusy(): {0}", 
                        ex.ToString() );
            }
           return View();
            }
            
        }


    }

