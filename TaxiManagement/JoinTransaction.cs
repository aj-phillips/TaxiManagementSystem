using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TaxiManagement
{
    public class JoinTransaction : Transaction
    {
        public int taxiNum { get; private set; }
        public int rankId { get; private set; }

        public JoinTransaction(DateTime transactionDateTime, int taxiNum, int rankId) : base("Join", transactionDateTime)
        {
            this.taxiNum = taxiNum;
            this.rankId = rankId;
        }

        public override string ToString()
        {
            return $"{TransactionDatetime:d} {TransactionDatetime:t} Join      - Taxi {taxiNum} in rank {rankId}";
        }
    }
}
