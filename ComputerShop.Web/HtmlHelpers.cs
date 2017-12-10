using ComputerShop.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ComputerShop.Web
{
    public static class HtmlHelpers
    {
        public static MvcHtmlString Stars(this HtmlHelper html, double mark)
        {
            int fullStars = (int)mark;
            if (fullStars > 5)
            {
                fullStars = 5;
            }
            int emptyStars = 5 - fullStars;
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < fullStars; i++)
            {
                result.Append(@"<span class=""glyphicon glyphicon-star""></span>");
            }
            for (int i = 0; i < emptyStars; i++)
            {
                result.Append(@"<span class=""glyphicon glyphicon-star-empty""></span>");
            }
            return MvcHtmlString.Create(result.ToString());
        }

        public static double CountMarks(this HtmlHelper html, Assembly assembly)
        {
            if (assembly.Comments.Count == 0)
            {
                return 0;
            }
            else
            {
                double marks = 0;
                int marksCount = 0;
                foreach (var comment in assembly.Comments)
                {
                    marksCount++;
                    marks += (int)comment.AssemblyGrade;
                }
                return marks / marksCount;
            }
        }
    }
}