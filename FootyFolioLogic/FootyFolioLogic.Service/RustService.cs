using FootyFolio.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootyFolioLogic.Service
{
    public class RustService : IRustService
    {
        public Task<bool> ProcessTransactionWithRustAsync(Guid userSellingId, Guid userBuyingId, Guid footballerId)
        {
            throw new NotImplementedException();
        }
    }
}
