using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Widget.Domain.Util {
    /// <summary>
    /// Utitlity methods for calculating prices.
    /// </summary>
    public static class PriceUtilities {
        private static readonly decimal DISCOUNT_AMOUNT = 0.1M;

        /// <summary>
        /// Calculate and return the discounted price for the Widget.
        /// </summary>
        /// <param name="widget">The Widget to extend.</param>
        /// <returns>The discounted price.</returns>
        public static decimal GetDiscountedPrice(this Models.Widget widget) {
            return widget.BasePrice * (1.0M - DISCOUNT_AMOUNT);
        }
    }
}
