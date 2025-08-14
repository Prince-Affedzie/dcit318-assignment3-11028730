using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance_Management_System
{
    public class MobileMoneyProcessor: ITransactionProcessor
    {
        public void Process(Transaction transaction)
        {
            Console.WriteLine($"Processing mobile money: ${transaction.Amount} for {transaction.Category} on {transaction.Date:d} (Tx #{transaction.Id})");
        }
    }
}
