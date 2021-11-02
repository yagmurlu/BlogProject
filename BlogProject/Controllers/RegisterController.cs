using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Controllers
{
    public class RegisterController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterRepository());
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Cities = GetCityList();
            return View();
        }
        [HttpPost]
        public IActionResult Index(Writer writer, string passwordAgain,string cities)
        {
            WriterValidator validationRules = new WriterValidator();
            ValidationResult results = validationRules.Validate(writer);
            if (results.IsValid && writer.WriterPassword==passwordAgain)
            {
                writer.WriterStatus = true;
                writer.About = "deneme Test";
                wm.WriterAdd(writer);
                return RedirectToAction("Index", "Blog");
            }
     
            else if(!results.IsValid)
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            else
            {
                ModelState.AddModelError("WriterPassword", "Şifreler Eşleşmedi!");
            }
            ViewBag.Cities = GetCityList();
            return View();
        }

        public List<SelectListItem> GetCityList()
        {
            List<SelectListItem> adminRole = (from x in GetCity()
                                              select new SelectListItem
                                              {
                                                  Text = x,
                                                  Value = x
                                              }).ToList();
            return adminRole;
        }
        public List<string> GetCity()
        {
            String[] CitiesArray = new string[]
            {
                "Adana","Adıyaman","Ankara","Ardahan","Bursa","Balıkesir","Burdur","Bayburt","Bitlis",
                "Ağrı","Bolu","Denizli","Diyarbakır","Mardin","ŞanlıUrfa","Gaziantep","Hakkari","Şırnak","Van","Kütahya",
                "Trabzon","Artvin","Rize","Karabük","Kırşehir","Kırıkkale","Kırklareli","Çanakkale","İzmir","Antalya",
                "Mersin","İstanbul","Edirne","Yozgat","Muğla","Kars","Kastamonu","Kilis","Hatay" 
            };
            return new List<string>(CitiesArray);
        }
    }
}
 