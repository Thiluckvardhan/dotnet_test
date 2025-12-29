using System;

namespace Question1
{
    /// <summary>
    /// This is Billing Service to create,view,clear the bill
    /// </summary>
    public class BillingService
    {
        #region static Things
        // Holds the most recently created bill in memory
        public static PatientBill LastBill;
        // Tracks whether a last bill exists (guards view/clear operations)
        public static bool HasLastBill = false;
        #endregion

        #region CreateBill Method
        /// <summary>
        /// Creates a new patient bill by collecting inputs, computes totals, and stores it as the last bill.
        /// </summary>
        public void CreateBill()
        {
            // Local variables to capture user inputs and perform calculations
            string billId;
            string name;
            string ins;
            bool insured;
            decimal consult;
            decimal lab;
            decimal med;

            //billid input
            Console.Write("\nEnter Bill Id: ");
            billId = Console.ReadLine();
            // Validate non-empty Bill Id
            if (string.IsNullOrWhiteSpace(billId))
            {
                Console.WriteLine("Bill Id cannot be empty.");
                return;
            }
            
            //patient name input
            Console.Write("Enter Patient Name: ");
            name = Console.ReadLine();

            //patient insurance input
            Console.Write("Is the patient insured (Y/N): ");
            ins = Console.ReadLine();

            string lower = ins == null ? "" : ins.ToLower();

            // Map common Y/N inputs to boolean insurance flag
            if (lower == "y" || lower == "yes")
            {
                insured = true;
            }
            else if (lower == "n" || lower == "no")
            {
                insured = false;
            }
            else
            {
                insured = false;
            }

            //consultation fee input
            Console.Write("Enter Consultation Fee: ");
            string input = Console.ReadLine();

            // Parse and validate consultation fee (> 0)
            if (!decimal.TryParse(input, out consult))
            {
                Console.WriteLine("Please enter a valid number.");
                return;
            }

            if (consult <= 0)
            {
                Console.WriteLine("Consultation Fee must be greater than 0.");
                return;
            }

            //lab charges input
            Console.Write("Enter Lab Charges: ");
            string labInput = Console.ReadLine();

            // Parse and validate lab charges (>= 0)
            if (!decimal.TryParse(labInput, out lab))
            {
                Console.WriteLine("Please enter a valid number.");
                return;
            }

            if (lab < 0)
            {
                Console.WriteLine("Lab Charges must be 0 or above.");
                return;
            }

            //Medical charges input
            Console.Write("Enter Medicine Charges: ");
            string medInput = Console.ReadLine();

            // Parse and validate medicine charges (>= 0)
            if (!decimal.TryParse(medInput, out med))
            {
                Console.WriteLine("Please enter a valid number.");
                return;
            }

            if (med < 0)
            {
                Console.WriteLine("Medicine Charges must be 0 or above.");
                return;
            }

            //adding the input to object 
            // Populate the bill object from collected inputs
            PatientBill bill = new PatientBill();
            bill.BillId = billId;
            bill.PatientName = name;
            bill.HasInsurance = insured;
            bill.ConsultationFee = consult;
            bill.LabCharges = lab;
            bill.MedicineCharges = med;

            // Compute gross amount before any discounts
            bill.GrossAmount = consult + lab + med;

            // Apply 10% discount for insured patients, rounded to 2 decimals
            if (insured)
                bill.DiscountAmount = Math.Round(bill.GrossAmount * 0.10m, 2);
            else
                bill.DiscountAmount = 0;

            // Net payable after discount
            bill.FinalPayable = bill.GrossAmount - bill.DiscountAmount;

            // Persist as the last bill for viewing/clearing later
            LastBill = bill;
            HasLastBill = true;

            // Output a brief summary to the console
            Console.WriteLine();
            Console.WriteLine("Bill created successfully.");
            Console.WriteLine($"Gross Amount: {bill.GrossAmount:F2}");
            Console.WriteLine($"Discount Amount: {bill.DiscountAmount:F2}");
            Console.WriteLine($"Final Payable: {bill.FinalPayable:F2}");
            Console.WriteLine("*************************************\n");
        }
        #endregion

        #region ViewBill Method
        /// <summary>
        /// Displays the most recently created bill; shows a message if none exists.
        /// </summary>
        public void ViewBill()
        {
            // Guard: No bill to show if none created yet
            if (!HasLastBill)
            {
                Console.WriteLine("No bill available. Please create a new bill first.");
                return;
            }

            // Display last bill details with basic formatting
            Console.WriteLine();
            Console.WriteLine("*******************Last Bill**********************");
            Console.WriteLine($"BillId: {LastBill.BillId}");
            Console.WriteLine($"Patient: {LastBill.PatientName}");
            Console.WriteLine($"Insured: {(LastBill.HasInsurance ? "Yes" : "No")}");
            Console.WriteLine($"Consultation Fee: {LastBill.ConsultationFee:F2}");
            Console.WriteLine($"Lab Charges: {LastBill.LabCharges:F2}");
            Console.WriteLine($"Medicine Charges: {LastBill.MedicineCharges:F2}");
            Console.WriteLine($"Gross Amount: {LastBill.GrossAmount:F2}");
            Console.WriteLine($"Discount Amount: {LastBill.DiscountAmount:F2}");
            Console.WriteLine($"Final Payable: {LastBill.FinalPayable:F2}");
            Console.WriteLine("********************************************\n");
        }
        #endregion

        #region ClearBill Method
        /// <summary>
        /// Clears the last stored bill and resets tracking flags.
        /// </summary>
        public void ClearBill()
        {
            // Reset in-memory state so a new bill can be created
            LastBill = null;
            HasLastBill = false;
            Console.WriteLine("Last bill cleared.");
        }
        #endregion
    }
}
