using System;

namespace Question2
{
    /// <summary>
    /// Handles creation, storage, display, and recalculation of sales transactions, including profit/loss metrics.
    /// </summary>
    public class TransactionService
    {
        #region static Things
        public static SaleTransaction LastTransaction;
        public static bool HasLastTransaction = false;
        #endregion

        #region CreateTransaction Method
        public void CreateTransaction()
        {
            //variable Declaration
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
            transaction = new SaleTransaction();
            transaction.InvoiceNo = invoice;
            transaction.CustomerName = customer;
            transaction.ItemName = item;
            transaction.Quantity = qty;
            transaction.PurchaseAmount = purchase;
            transaction.SellingAmount = selling;

            Compute(transaction);

            LastTransaction = transaction;
            HasLastTransaction = true;

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
        public void ViewTransaction()
        {
            if (!HasLastTransaction)
            {
                Console.WriteLine("No transaction available. Please create a new transaction first.");
                return;
            }

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
        public void Recalculate()
        {
            if (!HasLastTransaction)
            {
                Console.WriteLine("No transaction available. Please create a new transaction first.");
                return;
            }

            Compute(LastTransaction);

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
        private void Compute(SaleTransaction t)
        {
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

            t.ProfitMarginPercent = (t.ProfitOrLossAmount / t.PurchaseAmount) * 100;
        }
        #endregion
    }
}
