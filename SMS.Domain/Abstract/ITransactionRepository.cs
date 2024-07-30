using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMS.Domain.Entities;

namespace SMS.Domain.Abstract
{
    public interface ITransactionRepository
    {
        IEnumerable<Transaction> GetAllTransactions();
        IEnumerable<Transaction> SearchTransactions(string searchTerm);
        void SaveTransaction(Transaction transactions);
        void UpdateTransaction(Transaction transactions);
        void DeleteTransaction(Transaction transactions);
        Transaction GetTransactionsById(int Id);
        void Dispose();
    }
}
