using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Widget.Domain.Abstract {
    public interface IStateRepository {
        decimal CalculateTaxAmount(decimal subTotal, int stateId);
    }
}
