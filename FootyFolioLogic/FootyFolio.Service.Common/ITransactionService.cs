using FootyFolio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FootyFolio.Service.Common
{
    public interface ITransactionService
    {
        Task<bool> InsertTransactionAsync(Transaction transaction);
    }
}
