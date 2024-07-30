using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMS.Domain.Abstract;
using SMS.Domain.Entities;

namespace SMS.Domain.Concrete
{
    public class EFTransactionRepository : ITransactionRepository
    {
        private readonly EFDbContext context = new EFDbContext();

        public void DeleteTransaction(Transaction transactions)
        {
            context.Entry(transactions).State = System.Data.Entity.EntityState.Deleted;

            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public IEnumerable<Transaction> GetAllTransactions()
        {
            { return context.Transactions; }
        }

        public Transaction GetTransactionsById(int Id)
        {
            return context.Transactions.Find(Id);
        }

        public void SaveTransaction(Transaction transactions)
        {
            context.Transactions.Add(transactions);

            context.SaveChanges();
        }

        public IEnumerable<Transaction> SearchTransactions(string searchTerm)
        {
            var Transactions = context.Transactions.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                Transactions = Transactions.Where(a => a.Transaction_Date.ToString().Contains(searchTerm.ToLower()));
            }

            return Transactions.ToList();
        }

        public void UpdateTransaction(Transaction transactions)
        {
            context.Entry(transactions).State = System.Data.Entity.EntityState.Modified;

            context.SaveChanges();
        }
    }
}

