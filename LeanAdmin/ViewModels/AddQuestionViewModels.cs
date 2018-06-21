using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LeanAdmin.Models;

namespace LeanAdmin.ViewModels
{
    public class AddQuestionViewModels
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }
        public int ControlId { get; set; }

        public SelectList ListControl { get; set; }
        public List<QuestionAttribute> QuestionAttributes { get; set; } = new List<QuestionAttribute>();
    }
}