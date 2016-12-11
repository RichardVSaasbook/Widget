using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Widget.WebClient.Models {
    public class MessageModel {
        public string Type { get; set; }
        public string Message { get; set; }

        public override string ToString() {
            TagBuilder message = new TagBuilder("div");
            message.AddCssClass("alert");
            message.AddCssClass($"alert-{Type}");

            message.InnerHtml = Message;

            return message.ToString();
        }
    }
}