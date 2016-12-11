using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Widget.Domain.Models;

namespace Widget.Domain.Abstract {
    public interface IStateRepository {
        List<State> ListStates();
        decimal CalculateTaxAmount(decimal subTotal, int stateId);
    }
}
