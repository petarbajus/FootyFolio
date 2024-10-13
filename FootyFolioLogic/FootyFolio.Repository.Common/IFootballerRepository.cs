using FootyFolio.Model;
using FootyFolioLogic.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootyFolio.Repository.Common
{
    public interface IFootballerRepository
    {
        Task<List<Footballer>> GetFootballersAsync(FootballerFilter footballerFilter);
        Task<List<Footballer>> GetFootballersByUserIdAsync(Guid userId);
    }
}
