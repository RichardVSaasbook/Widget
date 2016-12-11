using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Widget.Domain.Models;

namespace Widget.Tests {
    /// <summary>
    /// A Mocked DbContext for the WidgetDbContext and Mocked DbSets
    /// for the States and Widgets.
    /// </summary>
    public class MockWidgetDbContext {
        /// <summary>
        /// The Mock WidgetDbContext.
        /// </summary>
        public Mock<WidgetDbContext> MockContext { get; private set; }

        /// <summary>
        /// The Mock State DbSet.
        /// </summary>
        public Mock<DbSet<State>> MockStateSet { get; private set; }

        /// <summary>
        /// The Mock Widget DbSet.
        /// </summary>
        public Mock<DbSet<Domain.Models.Widget>> MockWidgetSet { get; private set; }

        /// <summary>
        /// Create a new Mock DbContext.
        /// </summary>
        public MockWidgetDbContext() {
            MockStateSet = SetupMockSet(new List<State> {
                new State {
                    Id = 1,
                    Name = "State 1",
                    Abbreviation = "S1",
                    TaxRate = 0.00M
                },
                new State {
                    Id = 2,
                    Name = "State 2",
                    Abbreviation = "S2",
                    TaxRate = 0.10M
                },
                new State {
                    Id = 3,
                    Name = "State 3",
                    Abbreviation = "S3",
                    TaxRate = 0.05M
                }
            });

            MockWidgetSet = SetupMockSet(new List<Domain.Models.Widget> {
                new Domain.Models.Widget {
                    Id = 1,
                    Name = "Widget 1",
                    BasePrice = 4.97M,
                    IsDiscounted = false
                },
                new Domain.Models.Widget {
                    Id = 2,
                    Name = "Widget 2",
                    BasePrice = 4.97M,
                    IsDiscounted = true
                },
                new Domain.Models.Widget {
                    Id = 3,
                    Name = "Widget 3",
                    BasePrice = 9.97M,
                    IsDiscounted = false
                }
            });

            MockContext = new Mock<WidgetDbContext>();
            MockContext.Setup(context => context.States).Returns(MockStateSet.Object);
            MockContext.Setup(context => context.Widgets).Returns(MockWidgetSet.Object);
        }

        /// <summary>
        /// Create a Mocked DbSet for the entity type.
        /// </summary>
        /// <typeparam name="T">The type of the entity.</typeparam>
        /// <param name="data">The List of entities that represents the DbSet.</param>
        /// <returns>The Mocked DbSet.</returns>
        private Mock<DbSet<T>> SetupMockSet<T>(IEnumerable<T> data) where T : class {
            IQueryable<T> qData = data.AsQueryable();
            Mock<DbSet<T>> mockSet = new Mock<DbSet<T>>();

            mockSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(qData.Provider);
            mockSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(qData.Expression);
            mockSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(qData.ElementType);
            mockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(qData.GetEnumerator());

            return mockSet;
        }
    }
}
