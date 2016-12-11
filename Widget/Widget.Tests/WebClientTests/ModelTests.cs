using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Widget.Domain.Abstract;
using Widget.Domain.Concrete;
using Widget.Domain.Models;
using Widget.WebClient.Models;
using Xunit;

namespace Widget.Tests.WebClientTests {
    public class ModelTests {
        private readonly IStateRepository stateRepository;
        private readonly IWidgetRepository widgetRepository;

        public ModelTests() {
            MockWidgetDbContext mockDb = new MockWidgetDbContext();

            stateRepository = new EfStateRepository(mockDb.MockContext.Object);
            widgetRepository = new EfWidgetRepository(mockDb.MockContext.Object);
        }

        /// <summary>
        /// Test to make sure that the WidgetIndexViewModel is created properly
        /// from the repository data.
        /// </summary>
        [Fact]
        public void Test_WidgetIndexViewModel_Create() {
            WidgetIndexViewModel indexModel = WidgetIndexViewModel.Create(stateRepository, widgetRepository);
            List<State> states = stateRepository.ListStates();
            List<Domain.Models.Widget> widgets = widgetRepository.ListWidgets();

            for (int s = 0; s < states.Count; s++) {
                State expectedState = states[s];

                State state = indexModel.States[s];
                SelectListItem stateItem = indexModel.StateItems[s];

                Assert.Equal(expectedState.Name, state.Name);
                Assert.Equal(expectedState.Name, stateItem.Text);
                Assert.Equal(expectedState.Id.ToString(), stateItem.Value);
            }

            Assert.Equal(3, indexModel.States.Count);
            Assert.Equal(3, indexModel.StateItems.Count);

            for (int w = 0; w < widgets.Count; w++) {
                Domain.Models.Widget expectedWidget = widgets[w];

                WidgetViewModel widgetModel = indexModel.Widgets[w];

                Assert.Equal(0, widgetModel.Quantity);
                Assert.Equal(expectedWidget.Name, widgetModel.Widget.Name);
            }

            Assert.Equal(3, indexModel.Widgets.Count);
        }

        /// <summary>
        /// Test to make sure that the WidgetIndexViewModel is created properly
        /// from the repository data and data from the form.
        /// </summary>
        [Fact]
        public void Test_WidgetIndexViewModel_CreateWithFormData() {
            int selectedState = 1;
            List<int> widgetQuantities = new List<int> { 1, 0, 3 };

            WidgetIndexViewModel indexModel = WidgetIndexViewModel.Create(stateRepository, widgetRepository, selectedState, widgetQuantities);
            List<State> states = stateRepository.ListStates();
            List<Domain.Models.Widget> widgets = widgetRepository.ListWidgets();

            for (int s = 0; s < states.Count; s++) {
                State expectedState = states[s];

                State state = indexModel.States[s];
                SelectListItem stateItem = indexModel.StateItems[s];

                Assert.Equal(expectedState.Name, state.Name);
                Assert.Equal(expectedState.Name, stateItem.Text);
                Assert.Equal(expectedState.Id.ToString(), stateItem.Value);
            }

            Assert.Equal(3, indexModel.States.Count);
            Assert.Equal(3, indexModel.StateItems.Count);
            Assert.Equal(1, indexModel.FormModel.SelectedState);

            for (int w = 0; w < widgets.Count; w++) {
                Domain.Models.Widget expectedWidget = widgets[w];

                WidgetViewModel widgetModel = indexModel.Widgets[w];
                int quantity = widgetQuantities[w];
                int formQuantity = indexModel.FormModel.WidgetQuantities[w];

                Assert.Equal(quantity, formQuantity);
                Assert.Equal(quantity, widgetModel.Quantity);
                Assert.Equal(expectedWidget.Name, widgetModel.Widget.Name);
            }

            Assert.Equal(3, indexModel.Widgets.Count);
            Assert.Equal(3, indexModel.FormModel.WidgetQuantities.Count);
        }

        /// <summary>
        /// Test to make sure the money amount calculations work properly.
        /// </summary>
        [Fact]
        public void Test_WidgetCalculateViewModel_Create() {
            int selectedState = 2;
            List<int> widgetQuantities = new List<int> { 1, 1, 2 };

            WidgetIndexViewModel indexModel = WidgetIndexViewModel.Create(stateRepository, widgetRepository, selectedState, widgetQuantities);
            WidgetCalculateViewModel calculateModel = WidgetCalculateViewModel.Create(indexModel);

            decimal expectedSubTotal = 4.97M + 4.97M + 2 * 9.97M;
            decimal expectedDiscountAmount = 4.97M * 0.1M;
            decimal expectedTaxAmount = (expectedSubTotal - expectedDiscountAmount) * 0.1M;
            decimal expectedTotalAmount = expectedSubTotal - expectedDiscountAmount + expectedTaxAmount;
            string expectedState = "State 2";

            Assert.Equal(expectedSubTotal.ToString("c"), calculateModel.SubTotal);
            Assert.Equal(expectedDiscountAmount.ToString("c"), calculateModel.DiscountAmount);
            Assert.Equal(expectedTaxAmount.ToString("c"), calculateModel.TaxAmount);
            Assert.Equal(expectedTotalAmount.ToString("c"), calculateModel.TotalAmount);
            Assert.Equal(expectedState, calculateModel.SelectedState.Name);
        }
    }
}
