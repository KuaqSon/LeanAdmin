using LeanAdmin.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeanAdmin.Controllers
{
    public class QuestionsController : Controller
    {
        //IEnumerable<Question> questions = new List<Question>
        //    {
        //        new Question { Id = 1,
        //        Label = "radio 1",
        //        Description = "a radio control",
        //        UpdatedDate = DateTime.Parse("2/2/2018"),
        //        ControlId =1},
        //        new Question { Id = 2,
        //        Label = "radio 2",
        //        Description = "a radio control",
        //        UpdatedDate = DateTime.Parse("1/6/2018"),
        //        ControlId =1 },
        //        new Question { Id = 3,
        //        Label = "radio 3",
        //        Description = "a radio control",
        //        UpdatedDate = DateTime.Parse("1/7/2018"),
        //        ControlId =1 },
        //        new Question { Id = 4,
        //        Label = "radio 4",
        //        Description = "a radio control",
        //        UpdatedDate = DateTime.Parse("1/9/2018"),
        //        ControlId =1 },
        //        new Question { Id = 5,
        //        Label = "radio 5",
        //        Description = "a radio control",
        //        UpdatedDate = DateTime.Parse("1/1/2018"),
        //        ControlId =1 },
        //        new Question { Id = 6,
        //        Label = "radio 6",
        //        Description = "a radio control",
        //        UpdatedDate = DateTime.Parse("1/1/2018"),
        //        ControlId =1 },
        //        new Question { Id = 7,
        //        Label = "radio 7",
        //        Description = "a radio control a radio control a radio control a radio control a radio control a radio control a radio control a radio control a radio control a radio control a radio control a radio control",
        //        UpdatedDate = DateTime.Parse("1/1/2018"),
        //        ControlId =1 },
        //        new Question { Id = 8,
        //        Label = "radio 8",
        //        Description = "a radio control",
        //        UpdatedDate = DateTime.Parse("1/1/2018"),
        //        ControlId =1 },
        //        new Question { Id = 9,
        //        Label = "radio 9",
        //        Description = "a radio control",
        //        UpdatedDate = DateTime.Parse("1/1/2018"),
        //        ControlId =1 },
        //        new Question { Id = 10,
        //        Label = "radio 10",
        //        Description = "a radio control",
        //        UpdatedDate = DateTime.Parse("1/1/2018"),
        //        ControlId =1 },

        //    };

        private LeanDbContext db = new LeanDbContext();
        // GET: Questions
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            var question = db.questions.Select(x => x);
            question = question.OrderBy(x => x.Id);
            var pageSize = 4;
            var pageNumber = (page ?? 1);
            var listQuestions = question.ToPagedList(pageNumber, pageSize);
            return View(listQuestions);
        }

        public ActionResult AddQuestion(string Title)
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddQuestion(Question question)
        {
            if (ModelState.IsValid)
            {
                question.UpdatedDate = DateTime.Now;
                db.questions.Add(question);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(question);
        }

        public ActionResult DeleteQuestion(string listItem)
        {
            var listQues = listItem.Split('-');
            foreach (var item in listQues)
            {
                if (item =="")
                {
                    return RedirectToAction("Index");
                }
                var id = int.Parse(item);
                var delItem = db.questions.Find(id);
                if (delItem != null)
                {
                    db.questions.Remove(delItem);
                    db.SaveChanges();
                }               
            }
            return RedirectToAction("Index");   
        }


    }
}