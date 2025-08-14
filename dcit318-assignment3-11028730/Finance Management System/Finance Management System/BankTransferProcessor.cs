﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance_Management_System
{
    public class BankTransferProcessor: ITransactionProcessor
    {
        public void Process(Transaction transaction)
        {
            Console.WriteLine($"Processing bank transfer: ${transaction.Amount} for {transaction.Category}  on {transaction.Date:d} (Tx #{transaction.Id})");
        }
    }
}
