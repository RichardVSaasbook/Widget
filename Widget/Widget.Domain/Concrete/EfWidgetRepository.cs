using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Widget.Domain.Abstract;
using Widget.Domain.Models;

namespace Widget.Domain.Concrete {
    public class EfWidgetRepository : IWidgetRepository {
        private WidgetDbContext db;

        /// <summary>
        /// Create a WidgetRepository with the database connected WidgetDbContext.
        /// </summary>
        public EfWidgetRepository() {
            db = new WidgetDbContext();
        }

        /// <summary>
        /// Create a WidgetRepository with the provided WidgetDbContext.
        /// </summary>
        /// <param name="db">The WidgetDbContext to get data from.</param>
        public EfWidgetRepository(WidgetDbContext db) {
            this.db = db;
        }

        /// <summary>
        /// List all of the Widgets in the database.
        /// </summary>
        /// <returns>The List of Widgets.</returns>
        public List<Models.Widget> ListWidgets() {
            return db.Widgets.ToList();
        }
    }
}
