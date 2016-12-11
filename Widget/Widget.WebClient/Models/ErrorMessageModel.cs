using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Widget.WebClient.Models {
    public class ErrorMessageModel : MessageModel {
        private TagBuilder errorList;
        private StringBuilder innerHtml;

        public ErrorMessageModel() : base() {
            errorList = new TagBuilder("ul");
            innerHtml = new StringBuilder();

            Type = "danger";
        }

        public void AddError(string error) {
            innerHtml.Append("<li>");
            innerHtml.Append(error);
            innerHtml.Append("</li>");
        }

        public override string ToString() {
            errorList.InnerHtml = innerHtml.ToString();
            Message = $"<span>The following errors have occurred:</span>{errorList.ToString()}";
            return base.ToString();
        }
    }
}