using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance_Management_System
{
    internal interface ITransactionProcessor
    {
        void Process(Transaction transaction);
    }
}
