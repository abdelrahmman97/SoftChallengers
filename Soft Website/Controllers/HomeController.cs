using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Soft_Website.Models;
using System.Net.Mail;
using System.Net;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [Route("Index")]
        [Route("")]
        public ActionResult Index()
        {
            var qry = db.Works.ToList().Take(4);
            return View(qry);
        }

        [Route("About")]
        public ActionResult About()
        {
            return View(db.Teams.ToList());
        }

        [HttpGet]
        [Route("Contact")]
        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        [Route("Contact")]
        public ActionResult Contact(Contact contact)
        {

            var mail = new MailMessage();
            var loginInfo = new NetworkCredential("softchallengers14@gmail.com", "mo..hamedAli14");
            mail.From = new MailAddress(contact.E_mail);
            mail.To.Add(new MailAddress("mohosny14@gmail.com"));

            mail.IsBodyHtml = true;
            string body = "Name : " + contact.name + "<br>" +
                            "Email: " + contact.E_mail + "<br>" +
                            "Phone number : " + contact.phoneNum + "<br>" +
                             "Message: <b>" + contact.message + "</b>";

            mail.Body = body;

            var smtpClient = new SmtpClient("smtp.gmail.com", 587); // 587 this is Gmail Port

            smtpClient.EnableSsl = true;

            smtpClient.Credentials = loginInfo;
            smtpClient.Send(mail);
            TempData["shortMessage"] = "Your Message Sent Successfully!, and we will communicate with you soon.";
            return RedirectToAction("RedirectPage");
        }

        [Route("Portfolio")]
        public ActionResult Portfolio()
        {
            return View(db.Works.ToList());
        }

        // GET: Details/5
        [Route("Details/{id}")]
        public ActionResult Details(int? id) /// To show project(Portfolio) details
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Work work = db.Works.Find(id);
            if (work == null)
            {
                return HttpNotFound();
            }
            return View(work);
        }

        public ActionResult RedirectPage()
        {
            ViewBag.msg = TempData["shortMessage"].ToString();
            return View();
        }
    }
}