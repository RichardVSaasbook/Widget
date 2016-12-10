using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Widget.Domain.Abstract;
using Xunit;

namespace Widget.Tests.DomainTests {
    public class TaxRateRepositoryTests {
        private IStateRepository repository;

        public TaxRateRepositoryTests() {
            // TODO: create TaxRateRepository
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

            Exception ex = Assert.Throws<ArgumentOutOfRangeException>(() => repository.CalculateTaxAmount(subTotal, stateId));
            Assert.Equal("Sub total of '-13.97' is not valid because it is negative.", ex.Message);
        }

        /// <summary>
        /// Test that the CalculateTaxAmount throws the proper error if
        /// a State with the provided ID does not exist.
        /// </summary>
        [Fact]
        public void Test_CalculateTaxAmount_StateNotFound() {
            decimal subTotal = 45.67M;
            int stateId = 4;

            Exception ex = Assert.Throws<ArgumentOutOfRangeException>(() => repository.CalculateTaxAmount(subTotal, stateId));
            Assert.Equal("State with ID of '4' does not exist.", ex.Message);
        }
    }
}
