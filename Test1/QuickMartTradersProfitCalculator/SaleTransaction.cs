namespace Question2
{  
    /// <summary>
    /// Sales transaction data model with quantities, amounts, and profit/loss metrics.
    /// Computed fields (status, amount, margin) are set by service logic.
    /// </summary>
    public class SaleTransaction
    {
        public string InvoiceNo { get; set; }
        public string CustomerName { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public decimal PurchaseAmount { get; set; }
        public decimal SellingAmount { get; set; }
        // Derived status: "PROFIT", "LOSS", or "BREAK EVEN"
        public string ProfitOrLossStatus { get; set; }
        // Absolute profit/loss amount based on selling vs. purchase totals
        public decimal ProfitOrLossAmount { get; set; }
        // Profit margin percentage relative to purchase amount
        public decimal ProfitMarginPercent { get; set; }
    }
}
