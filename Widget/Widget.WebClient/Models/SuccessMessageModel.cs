using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Widget.WebClient.Models {
    public class SuccessMessageModel : MessageModel {
        public SuccessMessageModel() : base() {
            Type = "success";
        }
    }
}