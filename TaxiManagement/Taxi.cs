using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;

namespace TaxiManagement
{
    public class Taxi
    {
        public static string IN_RANK = "in rank";
        public static string ON_ROAD = "on the road";
        private Rank _rank;

        public double CurrentFare { get; private set; }
        public string Destination { get; private set; }
        public string Location { get; private set; }
        public int Number { get; private set; }

        public Rank Rank
        {
            get => _rank;

            set
            {
                if (value != null)
                {
                    if (Destination == string.Empty)
                    {
                        _rank = value;
                        Location = IN_RANK;
                    }
                    else
                    {
                        throw new Exception("Cannot join rank if fare has not been dropped");
                    }
                }
                else
                {
                    throw new Exception("Rank cannot be null");
                }
            }
        }

        public double TotalMoneyPaid { get; private set; }

        public Taxi(int taxiNum)
        {
            CurrentFare = 0;
            Destination = "";
            Location = ON_ROAD;
            Number = taxiNum;
            TotalMoneyPaid = 0;
            _rank = null;
        }

        public void AddFare(string destination, double agreedPrice)
        {
            CurrentFare = agreedPrice;
            Destination = destination;
            Location = ON_ROAD;
            _rank = null;
        }

        public void DropFare(bool priceWasPaid)
        {
            if (priceWasPaid)
                TotalMoneyPaid += CurrentFare;

            Destination = string.Empty;
            CurrentFare = 0;
        }
    }
}
