using LeanAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeanAdmin.Controllers
{
    public class QuestionsController : Controller
    {
        // GET: Questions
        public ActionResult Index()
        {
            List<Question> questions = new List<Question>
            {
                new Question { Id = 1,
                Label = "radio",
                Description = "a radio control",
                UpdatedDate = DateTime.Parse("1/1/2018"),
                ControlId =1},
                
                new Question { Id = 2,
                Label = "radio",
                Description = "a radio control",
                UpdatedDate = DateTime.Parse("1/1/2018"),
                ControlId =1 }

            };
            return View(questions);
        }
    }
}