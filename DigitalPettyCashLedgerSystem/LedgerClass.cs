namespace DigitalPettyCashLedgerSystem
{
    /// <summary>
    /// Generic ledger class for managing a collection of transactions.
    /// </summary>
    public class Ledger<T> where T : Transaction
    {
        #region Fields
        private List<T> transactions = new List<T>();
        #endregion 

        #region AddEntry
        /// <summary>
        /// Adds a new transaction entry to the ledger.
        /// </summary>
        public void AddEntry(T entry)
        {
            transactions.Add(entry);
            Console.WriteLine("Entry Added Successfully");
        }
        #endregion

        #region GetTransactionsByDate
        /// <summary>
        /// Retrieves all transactions for a specific date.
        /// </summary>
        public List<T> GetTransactionsByDate(DateTime date)
        {
            return transactions.Where(t => t.Date == date).ToList();
        }
        #endregion

        #region CalculateTotal
        /// <summary>
        /// Calculates the total sum of all transactions in the ledger.
        /// </summary>
        public decimal CalculateTotal()
        {
            return transactions.Sum(t => t.Amount);
        }
        #endregion 
    }
}