namespace DigitalPettyCashLedgerSystem
{
    /// <summary>
    /// Entry point and main program class for the Digital Petty Cash Ledger System.
    /// </summary>
    public class UtilityClass
    {
        #region DisplayTotal & Main
        /// <summary>
        /// Displays the total amount for a given ledger based on transaction type.
        /// </summary>
        public static void DisplayTotal<T>(Ledger<T> ledger) where T : Transaction
        {
            if (typeof(T) == typeof(IncomeTransaction))
            {
                Console.WriteLine($"Total Income {ledger.CalculateTotal()}");
            }
            else
            {
                Console.WriteLine($"Total Expenses {ledger.CalculateTotal()}");
            }
        }
        /// <summary>
        /// Main entry point of the application. Demonstrates creating and managing income and expense ledgers.
        /// </summary>
        public static void Main()
        {
            Ledger<IncomeTransaction> incomeLedger = new Ledger<IncomeTransaction>();

            var income = new IncomeTransaction(1, DateTime.Now, 500m, "500 added", "Main Cash");
            incomeLedger.AddEntry(income);

            Ledger<ExpenseTransaction> expenseLedger = new Ledger<ExpenseTransaction>();
            var expense = new ExpenseTransaction(1, DateTime.Now, 20m, "20 debited ", "Stationery");
            expenseLedger.AddEntry(expense);
            expense = new ExpenseTransaction(2, DateTime.Now, 15m, "20 debited ", "Stationery");
            expenseLedger.AddEntry(expense);

            DisplayTotal(incomeLedger);
            DisplayTotal(expenseLedger);

            decimal NetBalance = incomeLedger.CalculateTotal() - expenseLedger.CalculateTotal();
            Console.WriteLine($"Net Balance: {NetBalance}");

            //Compile Error check
            // expenseLedger.AddEntry(income);
            //polymorphic output 
            List<Transaction> allTransactions = new List<Transaction>();

            allTransactions.Add(income);
            allTransactions.Add(expense);

            foreach (var t in allTransactions)
            {
                Console.WriteLine(t.GetSummary());
            }

        }
        #endregion DisplayTotal & Main
    }
}
