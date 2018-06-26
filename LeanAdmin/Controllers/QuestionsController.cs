using LeanAdmin.Models;
using LeanAdmin.ViewModels;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public ActionResult AddQuestion()
        {
            var model = new AddQuestionViewModels();
            model.ListControl = new SelectList(db.questionControls.ToList(), "Id", "Name");
            return View(model);
        }

        [HttpPost]
        public ActionResult AddQuestion(AddQuestionViewModels questionModel)
        {
            var question = new Question();
            var questionAttr = new QuestionAttribute();
            var QuestionId = 0;
            
            question.Label = questionModel.Label;
            question.Description = questionModel.Description;
            question.ControlId = questionModel.ControlId;

            if (ModelState.IsValid)
            {
                question.UpdatedDate = DateTime.Now;
                db.questions.Add(question);
                db.SaveChanges();
                QuestionId = question.Id;
            }

            foreach ( var item in questionModel.QuestionAttributes)
            {
                questionAttr.Name = item.Name;
                questionAttr.Value = item.Value;
                questionAttr.QuestionId = QuestionId;
                if (ModelState.IsValid)
                {
                    questionAttr.UpdatedDate = DateTime.Now;
                    db.questionAttributes.Add(questionAttr);
                    db.SaveChanges();
                }
            }

            return RedirectToAction("Index");
            //return View(questionModel);
        }

        public ActionResult EditQuestion (int id)
        {
            var question = db.questions.Find(id);
            var model = new AddQuestionViewModels();

            model.Id = question.Id;
            model.Label = question.Label;
            model.Description = question.Description;
            model.ControlId = question.ControlId;
            model.ListControl = new SelectList(db.questionControls.ToList(), "Id", "Name");
            model.QuestionAttributes = new List<QuestionAttribute>(db.questionAttributes.Where(x => x.QuestionId == model.Id).ToList());
            return View(model);
        }

        [HttpPost]
        public ActionResult EditQuestion(AddQuestionViewModels questionModel)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            var question = new Question();
            var questionAttr = new QuestionAttribute();

            question.Id = questionModel.Id;
            question.Label = questionModel.Label;
            question.Description = questionModel.Description;
            question.ControlId = questionModel.ControlId;
            question.UpdatedDate = DateTime.Now;
            db.Entry(question).State = EntityState.Modified;
            db.SaveChanges();

            foreach (var item in questionModel.QuestionAttributes)
            {
                questionAttr.Name = item.Name;
                questionAttr.Value = item.Value;
                questionAttr.QuestionId = questionModel.Id;
                questionAttr.UpdatedDate = DateTime.Now;
                db.questionAttributes.Add(questionAttr);
            }

            foreach ( var id in questionModel.DeletedQuestionAttributes)
            {
                var DeleteItem = db.questionAttributes.Find(id);
                db.questionAttributes.Remove(DeleteItem);
            }

            db.SaveChanges();
            return RedirectToAction("Index");
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