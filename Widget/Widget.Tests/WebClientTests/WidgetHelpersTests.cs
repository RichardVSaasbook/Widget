using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Widget.WebClient.Helpers;
using Xunit;

namespace Widget.Tests.WebClientTests {
    public class WidgetHelpersTests {
        private readonly MockWidgetDbContext mockContext;

        public WidgetHelpersTests() {
            mockContext = new MockWidgetDbContext();
        }

        /// <summary>
        /// Test to make sure that the WidgetPrice extension method returns the proper
        /// HTML for a Widget with no discount.
        /// </summary>
        [Fact]
        public void Test_WidgetPrice_NoDiscount() {
            HtmlHelper helper = null;

            Domain.Models.Widget widget = new Domain.Models.Widget {
                BasePrice = 4.97M,
                IsDiscounted = false
            };

            Assert.Equal("<h5>$4.97</h5>", helper.WidgetPrice(widget).ToHtmlString());
        }

        /// <summary>
        /// Test to make sure that the WidgetPrice extension method returns the proper
        /// HTML for a Widget with a discount.
        /// </summary>
        [Fact]
        public void Test_WidgetPrice_Discount() {
            HtmlHelper helper = null;

            Domain.Models.Widget widget = new Domain.Models.Widget {
                BasePrice = 4.97M,
                IsDiscounted = true
            };

            StringBuilder expected = new StringBuilder();
            expected.Append("<h5><s>$4.97</s>&emsp;");
            expected.Append("<strong>$");
            expected.Append(Math.Round(4.97M * 0.9M, 2).ToString());
            expected.Append(@"</strong><span class=""pull-right label-primary label"">Discounted</span></h5>");

            Assert.Equal(expected.ToString(), helper.WidgetPrice(widget).ToHtmlString());
        }
    }
}
