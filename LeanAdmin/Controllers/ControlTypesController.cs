﻿using LeanAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeanAdmin.Controllers
{
    public class ControlTypesController : Controller
    {
        // GET: ControlTypes
        public ActionResult Index()
        {
            List<QuestionControl> questionsControl = new List<QuestionControl>
            {
                new QuestionControl { Id = 1,
                Name = "radio 1",
                Description = "a radio control",
                UpdatedDate = DateTime.Parse("1/1/2018") },
                new QuestionControl { Id = 2,
                Name = "radio 2",
                Description = "a radio control",
                UpdatedDate = DateTime.Parse("1/1/2018") },
                new QuestionControl { Id = 3,
                Name = "radio 3",
                Description = "a radio control",
                UpdatedDate = DateTime.Parse("1/1/2018") },
                new QuestionControl { Id = 4,
                Name = "radio 4",
                Description = "a radio control",
                UpdatedDate = DateTime.Parse("1/1/2018") },
                new QuestionControl { Id = 5,
                Name = "radio 5",
                Description = "a radio control",
                UpdatedDate = DateTime.Parse("1/1/2018") }

            };
            
            return View(questionsControl);
        }

        public ActionResult AddControl(string Title)
        {
            return View();
        }
    }
}