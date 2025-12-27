using System;

namespace Question1
{
    /// <summary>
    /// This the start of the program and runs till the user exits
    /// </summary>
    class Program
    {
        //main method
        static void Main(string[] args)
        {
            BillingService service = new BillingService();
            bool running = true;

            while (running)
            {
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
                        service.CreateBill();
                        break;

                    case "2":
                        service.ViewBill();
                        break;

                    case "3":
                        service.ClearBill();
                        break;

                    case "4":
                        running = false;
                        Console.WriteLine("Thank you. Application closed normally.");
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please try again.\n");
                        break;
                }
            }
        }
    }
}
