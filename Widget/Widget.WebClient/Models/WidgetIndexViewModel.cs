using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Widget.Domain.Models;

namespace Widget.WebClient.Models {
    public class WidgetIndexViewModel {
        public IEnumerable<SelectListItem> States { get; set; }
        public IEnumerable<Domain.Models.Widget> Widgets { get; set; }
    }
}