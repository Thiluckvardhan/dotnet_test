namespace DigitalPettyCashLedgerSystem
{
    /// <summary>
    /// Represents an expense transaction in the petty cash ledger.
    /// </summary>
    public class ExpenseTransaction : Transaction, IReportable
    {
        #region Category
        public string? Category { get; set; }
        #endregion Category

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the ExpenseTransaction class.
        /// </summary>
        public ExpenseTransaction(int id, DateTime date, decimal amount, string description, string category) : base(id, date, amount, description)
        {
            this.Category = category;
        }
        #endregion

        #region GetSummary
        /// <summary>
        /// Gets a summary of the expense transaction.
        /// </summary>
        public override string GetSummary()
        {
            return $"Expense - {Amount} , {Category}";
        }
        #endregion GetSummary
    }
}