using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Widget.Domain.Util;

namespace Widget.WebClient.Helpers {
    public static class WidgetHelper {
        /// <summary>
        /// Construct the HTML for displaying a Widget's price information.
        /// </summary>
        /// <param name="html">The HtmlHelper instance.</param>
        /// <param name="widget">THe Widget whose price to render.</param>
        /// <returns>The HtmlString for the Widget's price information.</returns>
        public static HtmlString WidgetPrice(this HtmlHelper html, Domain.Models.Widget widget) {
            TagBuilder price = new TagBuilder("h5");
            StringBuilder innerHtml = new StringBuilder(widget.BasePrice.ToString("c"));

            if (widget.IsDiscounted) {
                TagBuilder originalPrice = new TagBuilder("s");
                originalPrice.InnerHtml = innerHtml.ToString();

                TagBuilder discountedPrice = new TagBuilder("strong");
                discountedPrice.InnerHtml = widget.GetDiscountedPrice().ToString("c");

                TagBuilder discountLabel = new TagBuilder("span");
                discountLabel.AddCssClass("label");
                discountLabel.AddCssClass("label-primary");
                discountLabel.AddCssClass("pull-right");
                discountLabel.InnerHtml = "Discounted";

                innerHtml = new StringBuilder();
                innerHtml.Append(originalPrice.ToString());
                innerHtml.Append("&emsp;");
                innerHtml.Append(discountedPrice.ToString());
                innerHtml.Append(discountLabel.ToString());
            }

            price.InnerHtml = innerHtml.ToString();
            return new HtmlString(price.ToString());
        }
    }
}