using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance_Management_System
{
    public class FinanceApp
    {

        private List<Transaction> _transactions = new List<Transaction>();

        public void Run()
        {
           
            var savingsAccount = new SavingsAccount("123456789", 1000m);

            
            var transaction1 = new Transaction(1, DateTime.Now, 150m, "Groceries");
            var transaction2 = new Transaction(2, DateTime.Now, 75m, "Utilities");
            var transaction3 = new Transaction(3, DateTime.Now, 200m, "Entertainment");

            
            var mobileProcessor = new MobileMoneyProcessor();
            mobileProcessor.Process(transaction1);

            var bankProcessor = new BankTransferProcessor();
            bankProcessor.Process(transaction2);

            var cryptoProcessor = new CryptoWalletProcessor();
            cryptoProcessor.Process(transaction3);

           
            savingsAccount.ApplyTransaction(transaction1);
            savingsAccount.ApplyTransaction(transaction2);
            savingsAccount.ApplyTransaction(transaction3);

           
            _transactions.Add(transaction1);
            _transactions.Add(transaction2);
            _transactions.Add(transaction3);
        }

        public static void Main()
        {
            var app = new FinanceApp();
            app.Run();
        }
    }
}
