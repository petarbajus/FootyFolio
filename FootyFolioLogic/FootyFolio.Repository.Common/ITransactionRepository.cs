using FootyFolio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootyFolio.Repository.Common
{
    public interface ITransactionRepository
    {
        Task<bool> InsertTransactionAsync(Transaction transaction);
    }
}
