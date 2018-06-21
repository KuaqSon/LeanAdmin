using LeanAdmin.Models;
using LeanAdmin.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeanAdmin.Controllers
{
    public class ControlTypesController : Controller
    {
        private LeanDbContext db = new LeanDbContext();
        //List<QuestionControl> questionsControl = new List<QuestionControl>
        //    {
        //        new QuestionControl { Id = 1,
        //        Name = "radio 1",
        //        Description = "a radio control",
        //        UpdatedDate = DateTime.Parse("1/1/2018") },
        //        new QuestionControl { Id = 2,
        //        Name = "radio 2",
        //        Description = "a radio control",
        //        UpdatedDate = DateTime.Parse("1/1/2018") },
        //        new QuestionControl { Id = 3,
        //        Name = "radio 3",
        //        Description = "a radio control",
        //        UpdatedDate = DateTime.Parse("1/1/2018") },
        //        new QuestionControl { Id = 4,
        //        Name = "radio 4",
        //        Description = "a radio control",
        //        UpdatedDate = DateTime.Parse("1/1/2018") },
        //        new QuestionControl { Id = 5,
        //        Name = "radio 5",
        //        Description = "a radio control",
        //        UpdatedDate = DateTime.Parse("1/1/2018") }
        //    };
        // GET: ControlTypes
        public ActionResult Index()
        {
            var questionControls = db.questionControls.ToList();
            return View(questionControls);
        }

        public ActionResult AddControl(string Title)
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult AddControl(QuestionControl questionControl)
        {
            if (ModelState.IsValid)
            {
                questionControl.UpdatedDate = DateTime.Now;
                db.questionControls.Add(questionControl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(questionControl);
        }

        public ActionResult EditControl (int id)
        {
            var questionControl = db.questionControls.Find(id);
            return View(questionControl);
        }

        [HttpPost]
        public ActionResult EditControl(QuestionControl questionControl)
        {
            if (ModelState.IsValid)
            {
                questionControl.UpdatedDate = DateTime.Now;
                db.Entry(questionControl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(questionControl);
        }

        public ActionResult DeleteControl(string listItem)
        {
            var listControl = listItem.Split('-');
            foreach (var item in listControl)
            {
                if (item == "")
                {
                    return RedirectToAction("Index");
                }
                var id = int.Parse(item);
                var delItem = db.questionControls.Find(id);
                if (delItem != null)
                {
                    db.questionControls.Remove(delItem);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }
    }
}