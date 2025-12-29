using System;

namespace Question1
{
    /// <summary>
    /// This the start of the program and runs till the user exits
    /// </summary>
    class Program
    {
        /// <summary>
        /// Application entry point. Displays a menu loop and routes user selections to billing actions.
        /// </summary>
        static void Main(string[] args)
        {
            // Initialize the service and loop control flag
            BillingService service = new BillingService();
            bool running = true;

            while (running)
            {
                // Render menu options for user interaction
                Console.WriteLine("*************MediSure Clinic Billing ********************");
                Console.WriteLine("1. Create New Bill");
                Console.WriteLine("2. View Last Bill");
                Console.WriteLine("3. Clear Last Bill");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your option: ");

                string input = Console.ReadLine();
                Console.WriteLine();

                switch (input)
                {
                    case "1":
                        // Create a new bill (collect inputs and compute totals)
                        service.CreateBill();
                        break;

                    case "2":
                        // Display the most recently created bill
                        service.ViewBill();
                        break;

                    case "3":
                        // Clear the last bill from memory
                        service.ClearBill();
                        break;

                    case "4":
                        // Exit the application loop gracefully
                        running = false;
                        Console.WriteLine("Thank you. Application closed normally.");
                        break;

                    default:
                        // Handle invalid menu selections
                        Console.WriteLine("Invalid option. Please try again.\n");
                        break;
                }
            }
        }
    }
}
