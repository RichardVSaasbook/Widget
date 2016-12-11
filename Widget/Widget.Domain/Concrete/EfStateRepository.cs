using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Widget.Domain.Abstract;
using Widget.Domain.Models;

namespace Widget.Domain.Concrete {
    public class EfStateRepository : IStateRepository {
        private WidgetDbContext db;

        /// <summary>
        /// Create a StateRepository with the database connected WidgetDbContext.
        /// </summary>
        public EfStateRepository() {
            db = new WidgetDbContext();
        }

        /// <summary>
        /// Create a StateRepository with the provided WidgetDbContext.
        /// </summary>
        /// <param name="db">The WidgetDbContext to get data from.</param>
        public EfStateRepository(WidgetDbContext db) {
            this.db = db;
        }

        /// <summary>
        /// Calculate the TaxAmount for a sub total based on the given state.
        /// </summary>
        /// <param name="subTotal">The sub total amount.</param>
        /// <param name="stateId">The ID of the State to calculate from.</param>
        /// <returns>
        ///     The calculated tax amount or 0.00 if subTotal is negative or
        ///     the State cannot be found.
        /// </returns>
        public decimal CalculateTaxAmount(decimal subTotal, int stateId) {
            if (subTotal < 0) {
                return 0M;
            }

            State state = db.States.FirstOrDefault(s => s.Id == stateId);

            if (state == null) {
                return 0M;
            }

            return subTotal * Math.Round(state.TaxRate, 2);
        }
    }
}
