using System;

namespace Question2
{
    /// <summary>
    /// Handles creation, storage, display, and recalculation of sales transactions, including profit/loss metrics.
    /// </summary>
    public class TransactionService
    {
        #region static Things
        // Holds the most recently saved transaction in memory
        public static SaleTransaction LastTransaction;
        // Tracks if a last transaction exists for view/recalculate operations
        public static bool HasLastTransaction = false;
        #endregion

        #region CreateTransaction Method
        /// <summary>
        /// Creates a new sales transaction by collecting inputs, validates them,
        /// computes profit/loss metrics, and stores it as the last transaction.
        /// </summary>
        public void CreateTransaction()
        {
            // Local variables to capture user inputs and perform calculations
            string invoice;
            string customer;
            string item;
            string qtyInput;
            int qty;
            string pInput;
            decimal purchase;
            string sInput;
            decimal selling;
            SaleTransaction transaction;

            //invoice input
            Console.Write("Enter Invoice No: ");
            invoice = Console.ReadLine();

            // Validate non-empty Invoice No
            if (string.IsNullOrWhiteSpace(invoice))
            {
                Console.WriteLine("Invoice No cannot be empty.");
                return;
            }
            //name input
            Console.Write("Enter Customer Name: ");
            customer = Console.ReadLine();

            //item input
            Console.Write("Enter Item Name: ");
            item = Console.ReadLine();

            //quantity input
            Console.Write("Enter Quantity: ");
            qtyInput = Console.ReadLine();
            // Parse and validate quantity (> 0)
            if (!int.TryParse(qtyInput, out qty))
            {
                Console.WriteLine("Please enter a valid number.");
                return;
            }
            if (qty <= 0)
            {
                Console.WriteLine("Quantity must be greater than 0.");
                return;
            }

            //purchase amount input
            Console.Write("Enter Purchase Amount (total): ");
            pInput = Console.ReadLine();
            // Parse and validate purchase amount (> 0)
            if (!decimal.TryParse(pInput, out purchase))
            {
                Console.WriteLine("Please enter a valid number.");
                return;
            }
            if (purchase <= 0)
            {
                Console.WriteLine("Purchase Amount must be greater than 0.");
                return;
            }

            //selling amount input
            Console.Write("Enter Selling Amount (total): ");
            sInput = Console.ReadLine();
            // Parse and validate selling amount (>= 0)
            if (!decimal.TryParse(sInput, out selling))
            {
                Console.WriteLine("Please enter a valid number.");
                return;
            }
            if (selling < 0)
            {
                Console.WriteLine("Selling Amount must be 0 or above.");
                return;
            }

            //adding input to saletransaction object
            // Populate the transaction object from collected inputs
            transaction = new SaleTransaction();
            transaction.InvoiceNo = invoice;
            transaction.CustomerName = customer;
            transaction.ItemName = item;
            transaction.Quantity = qty;
            transaction.PurchaseAmount = purchase;
            transaction.SellingAmount = selling;

            // Compute profit/loss metrics for the transaction
            Compute(transaction);

            // Persist as the last transaction for viewing/recalculation later
            LastTransaction = transaction;
            HasLastTransaction = true;

            // Output a brief summary to the console
            Console.WriteLine();
            Console.WriteLine("Transaction saved successfully.");
            Console.WriteLine($"Status: {transaction.ProfitOrLossStatus}");
            Console.WriteLine($"Profit/Loss Amount: {transaction.ProfitOrLossAmount:F2}");
            Console.WriteLine($"Profit Margin: {transaction.ProfitMarginPercent:F2}");
            Console.WriteLine("***************************************************************");
            Console.WriteLine();
        }
        #endregion

        #region ViewTransaction Method
        /// <summary>
        /// Displays the most recently saved transaction; shows a message if none exists.
        /// </summary>
        public void ViewTransaction()
        {
            // Guard: No transaction to show if none created yet
            if (!HasLastTransaction)
            {
                Console.WriteLine("No transaction available. Please create a new transaction first.");
                return;
            }

            // Display last transaction details with basic formatting
            Console.WriteLine();
            Console.WriteLine("***********************Last Transaction**************************");
            Console.WriteLine($"InvoiceNo: {LastTransaction.InvoiceNo}");
            Console.WriteLine($"Customer: {LastTransaction.CustomerName}");
            Console.WriteLine($"Item: {LastTransaction.ItemName}");
            Console.WriteLine($"Quantity: {LastTransaction.Quantity}");
            Console.WriteLine($"Purchase Amount: {LastTransaction.PurchaseAmount:F2}");
            Console.WriteLine($"Selling Amount: {LastTransaction.SellingAmount:F2}");
            Console.WriteLine($"Status: {LastTransaction.ProfitOrLossStatus}");
            Console.WriteLine($"Profit/Loss Amount: {LastTransaction.ProfitOrLossAmount:F2}");
            Console.WriteLine($"Profit Margin: {LastTransaction.ProfitMarginPercent:F2}");
            Console.WriteLine("*********************************************");
            Console.WriteLine();
        }
        #endregion

        #region Recalculate Method
        /// <summary>
        /// Recomputes profit/loss metrics for the last transaction and prints the updated values.
        /// </summary>
        public void Recalculate()
        {
            // Guard: ensure we have a transaction to recalculate
            if (!HasLastTransaction)
            {
                Console.WriteLine("No transaction available. Please create a new transaction first.");
                return;
            }

            // Recompute metrics using the existing transaction data
            Compute(LastTransaction);

            // Output recalculation results
            Console.WriteLine();
            Console.WriteLine("Recalculated Successfully.");
            Console.WriteLine($"Status: {LastTransaction.ProfitOrLossStatus}");
            Console.WriteLine($"Profit/Loss Amount: {LastTransaction.ProfitOrLossAmount:F2}");
            Console.WriteLine($"Profit Margin: {LastTransaction.ProfitMarginPercent:F2}");
            Console.WriteLine("**********************************************");
            Console.WriteLine();
        }
        #endregion

        #region Private Compute Method
        /// <summary>
        /// Computes the profit or loss status, amount, and margin percent for a transaction.
        /// </summary>
        private void Compute(SaleTransaction t)
        {
            // Determine status and absolute profit/loss amount
            if(t.SellingAmount > t.PurchaseAmount)
            {
                t.ProfitOrLossStatus = "PROFIT";
                t.ProfitOrLossAmount = t.SellingAmount - t.PurchaseAmount;
            }
            else if (t.SellingAmount < t.PurchaseAmount)
            {
                t.ProfitOrLossStatus = "LOSS";
                t.ProfitOrLossAmount = t.PurchaseAmount - t.SellingAmount;
            }
            else
            {
                t.ProfitOrLossStatus = "BREAK EVEN";
                t.ProfitOrLossAmount = 0;
            }

            // Calculate profit margin percentage relative to purchase amount
            t.ProfitMarginPercent = (t.ProfitOrLossAmount / t.PurchaseAmount) * 100;
        }
        #endregion
    }
}
