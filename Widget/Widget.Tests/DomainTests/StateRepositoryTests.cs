using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Widget.Domain.Abstract;
using Widget.Domain.Concrete;
using Xunit;

namespace Widget.Tests.DomainTests {
    public class StateRepositoryTests {
        private IStateRepository repository;

        public StateRepositoryTests() {
            repository = new EfStateRepository(new MockWidgetDbContext().MockContext.Object);
        }

        /// <summary>
        /// Test that the tax amount is the right amount if provided a proper
        /// money sub total and state ID.
        /// </summary>
        [Fact]
        public void Test_CalculateTaxAmount_Success() {
            decimal subTotal = 45.67M;
            int stateId = 2;

            decimal expected = 45.67M * 0.10M;
            decimal actual = repository.CalculateTaxAmount(subTotal, stateId);

            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// Test that the CalculateTaxAmount throws the proper error if
        /// the sub total money is negative.
        /// </summary>
        [Fact]
        public void Test_CalculateTaxAmount_NegativeSubTotal() {
            decimal subTotal = -13.97M;
            int stateId = 2;

            decimal expected = 0;
            decimal actual = repository.CalculateTaxAmount(subTotal, stateId);
            
            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// Test that the CalculateTaxAmount throws the proper error if
        /// a State with the provided ID does not exist.
        /// </summary>
        [Fact]
        public void Test_CalculateTaxAmount_StateNotFound() {
            decimal subTotal = 45.67M;
            int stateId = 4;

            decimal expected = 0;
            decimal actual = repository.CalculateTaxAmount(subTotal, stateId);

            Assert.Equal(expected, actual);
        }
    }
}
