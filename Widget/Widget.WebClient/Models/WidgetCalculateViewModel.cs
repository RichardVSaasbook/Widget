using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Widget.Domain.Models;
using Widget.Domain.Util;

namespace Widget.WebClient.Models {
    public class WidgetCalculateViewModel {
        public static WidgetCalculateViewModel Create(WidgetIndexViewModel indexModel) {
            decimal subTotal = 0,
                discountTotal = 0,
                taxTotal;
            int numberOfWidgetsSelected = 0;
            State selectedState = indexModel.States.FirstOrDefault(s => s.Id == indexModel.FormModel.SelectedState);

            foreach (WidgetViewModel widget in indexModel.Widgets) {
                if (widget.Quantity > 0) {
                    numberOfWidgetsSelected++;

                    subTotal += widget.Widget.BasePrice * widget.Quantity;
                    discountTotal += (widget.Widget.BasePrice - widget.Widget.GetDiscountedPrice()) * widget.Quantity;
                }
            }

            taxTotal = (subTotal - discountTotal) * selectedState.TaxRate;

            return new WidgetCalculateViewModel {
                IndexModel = indexModel,
                NumberOfWidgetsSelected = numberOfWidgetsSelected,
                SelectedState = selectedState,
                SubTotal = subTotal.ToString("c"),
                DiscountAmount = discountTotal.ToString("c"),
                TaxAmount = taxTotal.ToString("c"),
                TotalAmount = (subTotal - discountTotal + taxTotal).ToString("c")
            };
        }

        public WidgetIndexViewModel IndexModel { get; set; }
        public int NumberOfWidgetsSelected { get; set; }
        public State SelectedState { get; set; }
        public string SubTotal { get; set; }
        public string DiscountAmount { get; set; }
        public string TaxAmount { get; set; }
        public string TotalAmount { get; set; }
    }
}