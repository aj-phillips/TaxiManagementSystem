using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Serialization;
using System.Text;
using System.Transactions;

namespace TaxiManagement
{
    public class UserUI
    {
        private RankManager rankMgr;
        private TaxiManager taxiMgr;
        private TransactionManager transactionMgr;

        public UserUI(RankManager rkMgr, TaxiManager txMgr, TransactionManager trMgr)
        {
            rankMgr = rkMgr;
            taxiMgr = txMgr;
            transactionMgr = trMgr;
        }

        public List<string> TaxiDropsFare(int taxiNum, bool pricePaid)
        {
            List<string> dropList = new List<string>();
            Taxi taxi = taxiMgr.FindTaxi(taxiNum);

            if (taxi != null && taxi.Location == "on the road" && taxi.Destination != string.Empty)
            {
                taxi.DropFare(pricePaid);

                dropList.Add(pricePaid
                    ? $"Taxi {taxiNum} has dropped its fare and the price was paid."
                    : $"Taxi {taxiNum} has dropped its fare and the price was not paid.");

                transactionMgr.RecordDrop(taxiNum, pricePaid);
            }
            else
            {
                dropList.Add($"Taxi {taxiNum} has not dropped its fare.");
            }

            return dropList;
        }

        public List<string> TaxiJoinsRank(int taxiNum, int rankId)
        {
            List<string> joinList = new List<string>();
            Taxi taxi = taxiMgr.FindTaxi(taxiNum);
            Rank rank = rankMgr.FindRank(rankId);

            if (taxi != null && rank != null)
            {
                if (taxi.Rank != null)
                {
                    joinList.Add($"Taxi {taxiNum} has not joined rank {rankId}.");
                    return joinList;
                }

                rank.AddTaxi(taxi);
                joinList.Add($"Taxi {taxiNum} has joined rank {rankId}.");
                transactionMgr.RecordJoin(taxiNum, rankId);
            }
            else if (taxi == null && rank != null)
            {
                taxi = taxiMgr.CreateTaxi(taxiNum);
                rank.AddTaxi(taxi);
                joinList.Add($"Taxi {taxiNum} has joined rank {rankId}.");
                transactionMgr.RecordJoin(taxiNum, rankId);
            }
            else
            {
                joinList.Add($"Taxi number or rank ID is invalid, please try again!");
            }

            return joinList;
        }

        public List<string> TaxiLeavesRank(int rankId, string destination, double agreedPrice)
        {
            List<string> leaveList = new List<string>();
            Rank rank = rankMgr.FindRank(rankId);

            if (rank == null)
            {
                leaveList.Add($"Rank does not exist!");
                return leaveList;
            }

            Taxi t = rank.FrontTaxiTakesFare(destination, agreedPrice);

            if (t != null && rank != null)
            {
                transactionMgr.RecordLeave(rankId, t);
                leaveList.Add($"Taxi {t.Number} has left rank {rankId} to take a fare to {destination} for £{agreedPrice}.");
            }
            else
            {
                leaveList.Add($"Taxi has not left rank {rankId}.");
            }

            return leaveList;
        }

        public List<string> ViewFinancialReport()
        {
            List<string> financeList = new List<string>();
            SortedDictionary<int, Taxi> taxisDict = taxiMgr.GetAllTaxis();
            double totalPaidAllTaxis = 0;

            financeList.Add("Financial report");
            financeList.Add("================");

            if (taxisDict.Count == 0)
            {
                financeList.Add("No taxis, so no money taken");
            }
            else
            {
                foreach (var entry in taxisDict)
                {
                    financeList.Add(string.Format("Taxi {0}      {1:0.00}", entry.Value.Number, entry.Value.TotalMoneyPaid));

                    totalPaidAllTaxis += entry.Value.TotalMoneyPaid;
                }

                financeList.Add("           ======");

                financeList.Add($"Total:       {totalPaidAllTaxis:0.00}");
                financeList.Add("           ======");
            }

            return financeList;
        }

        public List<string> ViewTaxiLocations()
        {
            List<string> locationList = new List<string>();
            SortedDictionary<int, Taxi> taxisDict = taxiMgr.GetAllTaxis();

            locationList.Add("Taxi locations");
            locationList.Add("==============");

            if (taxisDict.Count == 0)
            {
                locationList.Add("No taxis");
            }
            else
            {
                foreach (var entry in taxisDict)
                {
                    if (entry.Value.Rank != null)
                    {
                        locationList.Add($"Taxi {entry.Value.Number} is in rank {entry.Value.Rank.Id}");
                    }
                    else if (entry.Value.Location == "on the road")
                    {
                        locationList.Add(entry.Value.Destination == string.Empty
                            ? $"Taxi {entry.Value.Number} is on the road"
                            : $"Taxi {entry.Value.Number} is on the road to {entry.Value.Destination}");
                    }
                }
            }

            return locationList;
        }

        public List<string> ViewTransactionLog()
        {
            List<string> logList = new List<string>();
            List<Transaction> transactionLog = transactionMgr.GetAllTransactions();
            SortedDictionary<int, Taxi> taxisDict = taxiMgr.GetAllTaxis();

            logList.Add("Transaction report");
            logList.Add("==================");

            if (transactionLog.Count == 0)
            {
                logList.Add("No transactions");
            }
            else
            {
                foreach (var transaction in transactionLog)
                {
                    logList.Add(transaction.ToString());
                }
            }

            return logList;
        }
    }
}
