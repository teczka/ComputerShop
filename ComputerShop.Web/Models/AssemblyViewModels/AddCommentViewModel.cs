using ComputerShop.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComputerShop.Web.Models.AssemblyViewModels
{
    public class AddCommentViewModel
    {
        public int UserId { get; set; }
        public int AssemblyId { get; set; }
        public Assembly CommentedAssembly { get; set; }
        public string Grade { get; set; }
        public string Text { get; set; }
        public int CurrentUserId { get; set; }
    }
}