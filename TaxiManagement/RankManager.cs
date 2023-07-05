using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace TaxiManagement
{
    public class RankManager
    {
        private Dictionary<int, Rank> ranks;

        public RankManager()
        {
            Rank rank1 = new Rank(1, 5);
            Rank rank2 = new Rank(2, 2);
            Rank rank3 = new Rank(3, 4);

            ranks = new Dictionary<int, Rank> {{1, rank1}, {2, rank2}, {3, rank3}};
        }

        public bool AddTaxiToRank(Taxi t, int rankId)
        {
            var currentRank = t.Rank;
            var r1 = FindRank(rankId);

            if (currentRank == r1 || t.Destination != string.Empty || r1.numberOfTaxiSpaces < 1 || currentRank != null) return false;

            r1.AddTaxi(t);
            return true;
        }

        public Rank FindRank(int rankId)
        {
            if (!ranks.ContainsKey(rankId)) return null;

            Rank r2;
            ranks.TryGetValue(rankId, out r2);

            return r2;
        }

        public Taxi FrontTaxiInRankTakesFare(int rankId, string destination, double agreedPrice)
        {
            Rank r3 = FindRank(rankId);

            return r3 == null ? null : r3.FrontTaxiTakesFare(destination, agreedPrice);
        }
    }
}
