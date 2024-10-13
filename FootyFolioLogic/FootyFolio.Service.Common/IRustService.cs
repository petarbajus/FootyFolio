using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootyFolio.Service.Common
{
    public interface IRustService
    {
        Task<bool> ProcessTransactionWithRustAsync(Guid userSellingId, Guid userBuyingId, Guid footballerId);
    }
}
