namespace DigitalPettyCashLedgerSystem
{
    /// <summary>
    /// Interface for objects that can provide a summary report.
    /// </summary>
    public interface IReportable
    {
        #region GetSummary
        /// <summary>
        /// Gets a summary representation of the object.
        /// </summary>
        string GetSummary();
        #endregion GetSummary
    }
}