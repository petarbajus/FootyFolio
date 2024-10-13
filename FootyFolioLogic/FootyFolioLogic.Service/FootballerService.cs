using FootyFolio.Model;
using FootyFolio.Repository.Common;
using FootyFolio.Service.Common;
using FootyFolioLogic.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootyFolioLogic.Service
{
    public class FootballerService : IFootballerService
    {
        private readonly IFootballerRepository _footballerRepository;

        public FootballerService(IFootballerRepository footballerRepository)
        {
            _footballerRepository = footballerRepository;
        }
        public async Task<List<Footballer>> GetFootballersAsync(FootballerFilter footballerFilter)
        {
            return await _footballerRepository.GetFootballersAsync(footballerFilter);
        }


        public async Task<List<Footballer>> GetFootballersByUserIdAsync(Guid userId)
        {
            return await _footballerRepository.GetFootballersByUserIdAsync(userId);
        }
    }
}
