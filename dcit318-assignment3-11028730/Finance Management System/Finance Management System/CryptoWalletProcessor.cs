using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance_Management_System
{
    public class CryptoWalletProcessor : ITransactionProcessor
    {
        public void Process(Transaction transaction)
        {
            Console.WriteLine($"Processing crypto transaction: ${transaction.Amount} for {transaction.Category} on {transaction.Date:d} (Tx #{transaction.Id})");
        }
    }
}
