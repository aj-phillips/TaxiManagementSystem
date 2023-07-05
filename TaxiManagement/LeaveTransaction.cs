using System;
using System.Collections.Generic;
using System.Text;

namespace TaxiManagement
{
    public class LeaveTransaction : Transaction
    {
        public int taxiNum { get; private set; }
        public int rankId { get; private set; }
        public string destination { get; private set; }
        public double agreedPrice { get; private set; }

        public LeaveTransaction(DateTime transactionDateTime, int rankId, Taxi t) : base("Leave", transactionDateTime)
        {
            this.rankId = rankId;
            this.taxiNum = t.Number;
            this.destination = t.Destination;
            this.agreedPrice = t.CurrentFare;
        }

        public override string ToString()
        {
            return $"{TransactionDatetime:d} {TransactionDatetime:t} Leave     - Taxi {taxiNum} from rank {rankId} to {destination} for £{agreedPrice}";
        }
    }
}
