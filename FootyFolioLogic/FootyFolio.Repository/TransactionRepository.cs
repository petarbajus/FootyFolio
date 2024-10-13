using FootyFolio.Model;
using FootyFolio.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootyFolio.Repository
{
    public class TransactionRepository : ITransactionRepository
    {
        public Task<bool> InsertTransactionAsync(Transaction transaction)
        {
            throw new NotImplementedException();
        }
    }
}
