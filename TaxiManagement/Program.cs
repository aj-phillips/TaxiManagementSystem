using System;
using System.Collections.Generic;

namespace TaxiManagement
{
    class Program
    {
        private static UserUI ui;

        static void Main(string[] args)
        {
            RankManager rm = new RankManager();
            TaxiManager txm = new TaxiManager();
            TransactionManager trm = new TransactionManager();
            ui = new UserUI(rm, txm, trm);

            DisplayMenu();
        }

        private static void DisplayMenu()
        {
            Console.WriteLine("============");
            Console.WriteLine("    MENU");
            Console.WriteLine("============");

            Console.WriteLine("1) Taxi Joins Rank");
            Console.WriteLine("2) Taxi Leaves Rank");
            Console.WriteLine("3) Taxi Drops Fare");
            Console.WriteLine("4) View Financial Report");
            Console.WriteLine("5) View Transaction Log");
            Console.WriteLine("6) View Taxi Locations");

            Console.Write("\nYour Choice: ");
            int choice = ReadInteger(Console.ReadLine());

            while (choice < 1 || choice > 6)
            {
                Console.WriteLine("Please enter a number within the range of the menu items");

                Console.Write("\nYour Choice: ");
                choice = ReadInteger(Console.ReadLine());
            }

            switch (choice)
            {
                case 1:
                    TaxiJoinsRank();
                    break;
                case 2:
                    TaxiLeavesRank();
                    break;
                case 3:
                    TaxiDropsFare();
                    break;
                case 4:
                    ViewFinancialReport();
                    break;
                case 5:
                    ViewTransactionLog();
                    break;
                case 6:
                    ViewTaxiLocations();
                    break;
            }
        }

        private static void DisplayResults(List<string> results)
        {
            if (results == null)
            {
                Console.WriteLine("No results!");
            }
            else
            {
                foreach (var item in results)
                {
                    Console.WriteLine(item);
                }
            }
        }

        private static double ReadDouble(string prompt)
        {
            double dNum;

            if (double.TryParse(prompt, out dNum))
            {
                return dNum;
            }

            return 0;
        }

        private static int ReadInteger(string prompt)
        {
            int intNum;

            if (int.TryParse(prompt, out intNum))
            {
                return intNum;
            }

            return 0;
        }

        private static string ReadString(string prompt)
        {
            return prompt;
        }

        private static void TaxiDropsFare()
        {
            Console.Clear();
            Console.WriteLine("===============");
            Console.WriteLine("Taxi Drops Fare");
            Console.WriteLine("===============");

            Console.Write("\nPlease enter a taxi number: ");
            int taxiNum = ReadInteger(Console.ReadLine());

            Console.Write("\nWas the price paid? (yes/no): ");
            string wasPaid = ReadString(Console.ReadLine());

            Console.WriteLine("\n===========================\n");

            DisplayResults(ui.TaxiDropsFare(taxiNum, wasPaid == "yes"));

            Console.Write("\nWould you like to go back to the menu? (yes/no): ");
            string menuAns = ReadString(Console.ReadLine());

            if (menuAns == "yes")
            {
                Console.Clear();
                DisplayMenu();
            }
        }

        private static void TaxiJoinsRank()
        {
            Console.Clear();
            Console.WriteLine("===============");
            Console.WriteLine("Taxi Joins Rank");
            Console.WriteLine("===============");

            Console.Write("\nPlease enter a taxi number: ");
            int taxiNum = ReadInteger(Console.ReadLine());

            Console.Write("\nPlease enter a rank ID: ");
            int rankId = ReadInteger(Console.ReadLine());

            Console.WriteLine("\n===========================\n");

            DisplayResults(ui.TaxiJoinsRank(taxiNum, rankId));

            Console.Write("\nWould you like to go back to the menu? (yes/no): ");
            string menuAns = ReadString(Console.ReadLine());

            if (menuAns == "yes")
            {
                Console.Clear();
                DisplayMenu();
            }
        }

        private static void TaxiLeavesRank()
        {
            Console.Clear();
            Console.WriteLine("================");
            Console.WriteLine("Taxi Leaves Rank");
            Console.WriteLine("================");

            Console.Write("\nPlease enter a rank ID: ");
            int rankId = ReadInteger(Console.ReadLine());

            Console.Write("\nPlease enter a destination: ");
            string dest = ReadString(Console.ReadLine());

            Console.Write("\nPlease enter the agreed price: ");
            double agreedPrice = ReadDouble(Console.ReadLine());

            Console.WriteLine("\n===========================\n");

            DisplayResults(ui.TaxiLeavesRank(rankId, dest, agreedPrice));

            Console.Write("\nWould you like to go back to the menu? (yes/no): ");
            string menuAns = ReadString(Console.ReadLine());

            if (menuAns == "yes")
            {
                Console.Clear();
                DisplayMenu();
            }
        }

        private static void ViewFinancialReport()
        {
            Console.Clear();
            DisplayResults(ui.ViewFinancialReport());

            Console.Write("\nWould you like to go back to the menu? (yes/no): ");
            string menuAns = ReadString(Console.ReadLine());

            if (menuAns == "yes")
            {
                Console.Clear();
                DisplayMenu();
            }
        }

        private static void ViewTaxiLocations()
        {
            Console.Clear();
            DisplayResults(ui.ViewTaxiLocations());

            Console.Write("\nWould you like to go back to the menu? (yes/no): ");
            string menuAns = ReadString(Console.ReadLine());

            if (menuAns == "yes")
            {
                Console.Clear();
                DisplayMenu();
            }
        }

        private static void ViewTransactionLog()
        {
            Console.Clear();
            DisplayResults(ui.ViewTransactionLog());

            Console.Write("\nWould you like to go back to the menu? (yes/no): ");
            string menuAns = ReadString(Console.ReadLine());

            if (menuAns == "yes")
            {
                Console.Clear();
                DisplayMenu();
            }
        }
    }
}
