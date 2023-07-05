using System;
using System.Collections.Generic;
using System.Text;

namespace TaxiManagement
{
    public abstract class Transaction
    {
        public DateTime TransactionDatetime { get; private set; }
        public string TransactionType { get; private set; }

        protected Transaction(string type, DateTime dt)
        {
            TransactionDatetime = dt;
            TransactionType = type;
        }
    }
}
