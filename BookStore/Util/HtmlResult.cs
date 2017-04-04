using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Util
{
    public class HtmlResult : ActionResult
    {
        private string HtmlCode;
        public HtmlResult(string html)
        {
            HtmlCode = html;
        }
        public override void ExecuteResult(ControllerContext context)
        {
            string pageCode = "<!Doctype html> <html> <head> <title>";
            pageCode += "Main page </title>";
            pageCode += "<body> " + HtmlCode;
            pageCode += "</body> </html>";
            context.HttpContext.Response.Write(pageCode);
        }
    }
}