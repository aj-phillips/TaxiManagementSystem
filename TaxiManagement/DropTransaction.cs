    ﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TaxiManagement
{
    public class DropTransaction : Transaction
    {
        public int taxiNum { get; private set; }
        public bool priceWasPaid { get; private set; }

        public DropTransaction(DateTime transactionDateTime, int taxiNum, bool priceWasPaid) : base("Drop fare", transactionDateTime)
        {
            this.taxiNum = taxiNum;
            this.priceWasPaid = priceWasPaid;
        }

        public override string ToString()
        {
            return priceWasPaid ? $"{TransactionDatetime:d} {TransactionDatetime:t} Drop fare - Taxi {taxiNum}, price was paid" :
                $"{TransactionDatetime:d} {TransactionDatetime:t} Drop fare - Taxi {taxiNum}, price was not paid";
        }
    }
}
