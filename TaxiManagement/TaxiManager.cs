using System;
using System.Collections.Generic;
using System.Text;

namespace TaxiManagement
{
    public class TaxiManager
    {
        private SortedDictionary<int, Taxi> taxis;

        public TaxiManager()
        {
            taxis = new SortedDictionary<int, Taxi>();
        }

        public Taxi CreateTaxi(int taxiNum)
        {
            if (taxis.ContainsKey(taxiNum))
            {
                Taxi t1;
                taxis.TryGetValue(taxiNum, out t1);

                return t1;
            }

            Taxi t = new Taxi(taxiNum);
            taxis.Add(taxiNum, t);

            return t;
        }

        public Taxi FindTaxi(int taxiNum)
        {
            if (!taxis.ContainsKey(taxiNum)) return null;

            Taxi t2;
            taxis.TryGetValue(taxiNum, out t2);

            return t2;
        }

        public SortedDictionary<int, Taxi> GetAllTaxis()
        {
            return taxis;
        }
    }
}
