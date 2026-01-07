namespace DigitalPettyCashLedgerSystem
{
        /// <summary>
        /// Abstract base class representing a financial transaction in the petty cash ledger.
        /// </summary>
    public abstract class Transaction : IReportable
    {
        #region Id, Date, Amount, Description
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        #endregion Id, Date, Amount, Description

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the Transaction class.
        /// </summary>
        protected Transaction(int id, DateTime date, decimal amount, string description)
        {
            this.Id = id;
            this.Date = date;
            this.Amount = amount;
            this.Description = description;
        }
        #endregion

        #region GetSummary
        /// <summary>
        /// Gets a summary representation of the transaction.
        /// </summary>
        public abstract string GetSummary();
        #endregion GetSummary
    }
}