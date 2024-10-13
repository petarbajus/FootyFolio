using FootyFolio.Model;
using FootyFolio.Repository.Common;
using FootyFolio.Service.Common;
using System;
using System.Threading.Tasks;

namespace FootyFolioLogic.Service
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IRustService _rustService;  // Interface that communicates with Rust smart contract

        public TransactionService(ITransactionRepository transactionRepository, IRustService rustService)
        {
            _transactionRepository = transactionRepository;
            _rustService = rustService;
        }

        public async Task<bool> InsertTransactionAsync(Transaction transaction)
        {
            // Step 1: Process the transaction via Rust (handling the Stellar transfer, royalty payments, etc.)
            bool rustTransactionSuccess = await _rustService.ProcessTransactionWithRustAsync(
                transaction.UserSellingId,
                transaction.UserBuyingId,
                transaction.FootballerId
            );

            // Step 2: If the Rust smart contract transaction succeeds, insert it into the database
            if (rustTransactionSuccess)
            {
                // Call the repository to insert the transaction into the database
                var transactionInserted = await _transactionRepository.InsertTransactionAsync(transaction);

                // Return whether the transaction was successfully inserted into the database
                return transactionInserted;
            }
            else
            {
                // If Rust transaction failed, return false
                return false;
            }
        }
    }
}
