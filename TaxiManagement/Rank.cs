using System;
using System.Collections.Generic;
using System.Linq;

namespace TaxiManagement
{
    public class Rank
    {
        public int Id { get; }
        public int numberOfTaxiSpaces { get; private set; }
        public List<Taxi> taxiSpace;

        public Rank(int rankId, int numberOfSpaces)
        {
            Id = rankId;
            numberOfTaxiSpaces = numberOfSpaces;
            taxiSpace = new List<Taxi>();
        }

        public bool AddTaxi(Taxi t)
        {
            if (numberOfTaxiSpaces == 0) return false;

            t.Rank = this;
            taxiSpace.Add(t);
            numberOfTaxiSpaces--;

            return true;
        }

        public Taxi FrontTaxiTakesFare(string destination, double agreedPrice)
        {
            if (taxiSpace.Count == 0)
            {
                return null;
            }

            Taxi t1 = taxiSpace.First();
            t1.AddFare(destination, agreedPrice);
            taxiSpace.Remove(t1);
            numberOfTaxiSpaces++;

            return t1;
        }
    }
}
