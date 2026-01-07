namespace DigitalPettyCashLedgerSystem
{
    /// <summary>
    /// Represents an income transaction in the petty cash ledger.
    /// </summary>
    public class IncomeTransaction : Transaction, IReportable
    {
        #region Source
        public string? Source { get; set; }
        #endregion Source

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the IncomeTransaction class.
        /// </summary>
        public IncomeTransaction(int id, DateTime date, decimal amount, string description, string source) : base(id, date, amount, description)
        {
            this.Source = source;
        }
        #endregion

        #region GetSummary
        /// <summary>
        /// Gets a summary of the income transaction.
        /// </summary>
        public override string GetSummary()
        {
            return $"Income - {Amount} , {Source}";
        }
        #endregion GetSummary
    }
}