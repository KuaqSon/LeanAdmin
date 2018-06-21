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
        IEnumerable<Question> questions = new List<Question>
            {
                new Question { Id = 1,
                Label = "radio 1",
                Description = "a radio control",
                UpdatedDate = DateTime.Parse("2/2/2018"),
                ControlId =1},
                new Question { Id = 2,
                Label = "radio 2",
                Description = "a radio control",
                UpdatedDate = DateTime.Parse("1/6/2018"),
                ControlId =1 },
                new Question { Id = 3,
                Label = "radio 3",
                Description = "a radio control",
                UpdatedDate = DateTime.Parse("1/7/2018"),
                ControlId =1 },
                new Question { Id = 4,
                Label = "radio 4",
                Description = "a radio control",
                UpdatedDate = DateTime.Parse("1/9/2018"),
                ControlId =1 },
                new Question { Id = 5,
                Label = "radio 5",
                Description = "a radio control",
                UpdatedDate = DateTime.Parse("1/1/2018"),
                ControlId =1 },
                new Question { Id = 6,
                Label = "radio 6",
                Description = "a radio control",
                UpdatedDate = DateTime.Parse("1/1/2018"),
                ControlId =1 },
                new Question { Id = 7,
                Label = "radio 7",
                Description = "a radio control",
                UpdatedDate = DateTime.Parse("1/1/2018"),
                ControlId =1 },
                new Question { Id = 8,
                Label = "radio 8",
                Description = "a radio control",
                UpdatedDate = DateTime.Parse("1/1/2018"),
                ControlId =1 },
                new Question { Id = 9,
                Label = "radio 9",
                Description = "a radio control",
                UpdatedDate = DateTime.Parse("1/1/2018"),
                ControlId =1 },
                new Question { Id = 10,
                Label = "radio 10",
                Description = "a radio control",
                UpdatedDate = DateTime.Parse("1/1/2018"),
                ControlId =1 },

            };
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

            questions = questions.OrderBy(x => x.Id);
            var pageSize = 4;
            var pageNumber = (page ?? 1);
            var listQuestions = questions.ToPagedList(pageNumber, pageSize);
            return View(listQuestions);
        }

        public ActionResult AddQuestion(string Title)
        {
            return View();
        }

        public ActionResult DeleteQuestion(string listItem)
        {
            List<Question> questions = new List<Question>
            {
                new Question { Id = 1,
                Label = "radio 1",
                Description = "a radio control",
                UpdatedDate = DateTime.Parse("1/1/2018"),
                ControlId =1},
                new Question { Id = 2,
                Label = "radio 2",
                Description = "a radio control",
                UpdatedDate = DateTime.Parse("1/1/2018"),
                ControlId =1 },
                new Question { Id = 2,
                Label = "radio 3",
                Description = "a radio control",
                UpdatedDate = DateTime.Parse("1/1/2018"),
                ControlId =1 },
                new Question { Id = 2,
                Label = "radio 4",
                Description = "a radio control",
                UpdatedDate = DateTime.Parse("1/1/2018"),
                ControlId =1 },
                new Question { Id = 2,
                Label = "radio 5",
                Description = "a radio control",
                UpdatedDate = DateTime.Parse("1/1/2018"),
                ControlId =1 },
                new Question { Id = 2,
                Label = "radio 6",
                Description = "a radio control",
                UpdatedDate = DateTime.Parse("1/1/2018"),
                ControlId =1 },
                new Question { Id = 2,
                Label = "radio 7",
                Description = "a radio control",
                UpdatedDate = DateTime.Parse("1/1/2018"),
                ControlId =1 },
                new Question { Id = 2,
                Label = "radio 8",
                Description = "a radio control",
                UpdatedDate = DateTime.Parse("1/1/2018"),
                ControlId =1 },
                new Question { Id = 2,
                Label = "radio 9",
                Description = "a radio control",
                UpdatedDate = DateTime.Parse("1/1/2018"),
                ControlId =1 },
                new Question { Id = 2,
                Label = "radio 10",
                Description = "a radio control",
                UpdatedDate = DateTime.Parse("1/1/2018"),
                ControlId =1 },

            };
            var listQues = listItem.Split('-');
            foreach (var item in listQues)
            {
                if (item =="")
                {
                    return RedirectToAction("Index");
                }
                var id = int.Parse(item);
                var delItem = questions.Find(x => x.Id == id);
                if (item != null)
                {
                    questions.Remove(delItem);
                }               
            }

            return RedirectToAction("Index");   
        }


    }
}