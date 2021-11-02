using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Controllers
{
    public class NewsLetterController : Controller
    {
        NewsLetterManager newsLetter = new NewsLetterManager(new EfNewsLetterRepository());
        [HttpGet]
        public PartialViewResult SubscribeMail()
        {
            return PartialView();
        }
        [HttpPost]      
        public PartialViewResult SubscribeMail(NewsLetter letter)
        {
            letter.MailStatus = true;
            newsLetter.AddNewsLetter(letter);
            return PartialView();
        }
    }
}
