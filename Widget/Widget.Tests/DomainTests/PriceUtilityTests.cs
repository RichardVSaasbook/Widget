using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Widget.Domain.Util;
using Xunit;

namespace Widget.Tests.DomainTests {
    public class PriceUtilityTests {
        private readonly MockWidgetDbContext mockContext;

        public PriceUtilityTests() {
            mockContext = new MockWidgetDbContext();
        }

        /// <summary>
        /// Test to make sure the correct discounted price is returned.
        /// </summary>
        [Fact]
        public void Test_GetDiscountedPrice() {
            decimal widget1Expected = 4.97M,
                widget2Expected = 4.97M * 0.9M,
                widget3Expected = 9.97M;

            Assert.Equal(widget1Expected, GetWidget(1).GetDiscountedPrice());
            Assert.Equal(widget2Expected, GetWidget(2).GetDiscountedPrice());
            Assert.Equal(widget3Expected, GetWidget(3).GetDiscountedPrice());
        }

        /// <summary>
        /// Get a Widget from the Mock database.
        /// </summary>
        /// <param name="id">The Id of the Widget.</param>
        /// <returns>The Widget from the Mock database.</returns>
        private Domain.Models.Widget GetWidget(int id) {
            return mockContext.MockWidgetSet.Object.FirstOrDefault(w => w.Id == id);
        }
    }
}
