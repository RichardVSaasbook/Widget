using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Widget.WebClient.Models;
using Xunit;

namespace Widget.Tests.WebClientTests {
    public class MessageModelTests {
        /// <summary>
        /// Test to make sure the ErrorMessageModel returns the correct string.
        /// </summary>
        [Fact]
        public void Test_ErrorMessageModel_ToString() {
            ErrorMessageModel errorMessage = new ErrorMessageModel();
            errorMessage.AddError("Error 1");
            errorMessage.AddError("Error 2");
            errorMessage.AddError("Error 3");

            StringBuilder expected = new StringBuilder();
            expected.Append(@"<div class=""alert-danger alert"">");
            expected.Append("<span>The following errors have occurred:</span><ul>");
            expected.Append("<li>Error 1</li>");
            expected.Append("<li>Error 2</li>");
            expected.Append("<li>Error 3</li>");
            expected.Append("</ul></div>");

            Assert.Equal(expected.ToString(), errorMessage.ToString());
        }
        /// <summary>
        /// Test to make sure the SuccessMessageModel returns the correct string.
        /// </summary>
        [Fact]
        public void Test_SuccessMessageModel_ToString() {
            SuccessMessageModel successMessage = new SuccessMessageModel() {
                Message = "Success"
            };

            Assert.Equal(@"<div class=""alert-success alert"">Success</div>", successMessage.ToString());
        }
    }
}
