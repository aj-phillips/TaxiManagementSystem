using System;
using System.Collections.Generic;
using System.Text;

namespace TaxiManagement
{
    public class TransactionManager
    {
        private List<Transaction> transactions = new List<Transaction>();

        public void RecordDrop(int taxiNum, bool pricePaid)
        {
            DateTime currentTime = DateTime.Now;
            DropTransaction dt = new DropTransaction(currentTime, taxiNum, pricePaid);
            transactions.Add(dt);
        }

        public void RecordJoin(int taxiNum, int rankId)
        {
            DateTime currentTime = DateTime.Now;
            JoinTransaction nt = new JoinTransaction(currentTime, taxiNum, rankId);
            transactions.Add(nt);
        }

        public void RecordLeave(int rankId, Taxi t)
        {
            DateTime currentTime = DateTime.Now;
            LeaveTransaction lt = new LeaveTransaction(currentTime, rankId, t);
            transactions.Add(lt);
        }

        public List<Transaction> GetAllTransactions()
        {
            return transactions;
        }
    }
}
