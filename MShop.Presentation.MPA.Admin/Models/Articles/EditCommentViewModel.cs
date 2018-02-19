﻿
using System;
using System.ComponentModel.DataAnnotations;

namespace MShop.Presentation.MPA.Admin.Models.Articles
{
    public class EditCommentViewModel
    {
        public Guid Id { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
		public DateTime AddedDate { get; set; }
        public string UserIp { get; set; }
        public string AddedBy { get; set; }
        public string Comment { get; set; }
    }
}
