using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Widget.Domain.Abstract;
using Widget.Domain.Concrete;
using Xunit;

namespace Widget.Tests.DomainTests {
    public class WidgetRepositoryTests {
        private IWidgetRepository repository;

        public WidgetRepositoryTests() {
            repository = new EfWidgetRepository(new MockWidgetDbContext().MockContext.Object);
        }

        /// <summary>
        /// Test that the repository can return a list of all widgets.
        /// </summary>
        [Fact]
        public void Test_ListWidgets() {
            List<Domain.Models.Widget> widgets = repository.ListWidgets();

            Assert.Equal(3, widgets.Count);
            Assert.Equal("Widget 1", widgets[0].Name);
            Assert.Equal("Widget 2", widgets[1].Name);
            Assert.Equal("Widget 3", widgets[2].Name);
        }
    }
}
