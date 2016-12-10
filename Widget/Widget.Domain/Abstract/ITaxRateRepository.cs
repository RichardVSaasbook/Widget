using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Widget.Domain.Abstract {
    public interface ITaxRateRepository {
        decimal CalculateTaxAmount(decimal subTotal, string stateAbbreviation);
    }
}
