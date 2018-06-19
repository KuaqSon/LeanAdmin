using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LeanAdmin.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }

        [Display(Name = "Update Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime UpdatedDate { get; set; }
        public int ControlId { get; set; }
        public bool IsActive { get; set; }
    }
}