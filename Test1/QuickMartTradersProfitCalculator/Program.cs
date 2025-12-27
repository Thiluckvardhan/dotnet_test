using System;

namespace Question2
{
    /// <summary>
    /// This the start of the program and runs till the user exits
    /// </summary>
    class Program
    {

        //Main Method
        static void Main(string[] args)
        {
            TransactionService service = new TransactionService();
            bool running = true;

            while (running)
            {
                Console.WriteLine("**************QuickMart Traders*************");
                Console.WriteLine("1. Create New Transaction");
                Console.WriteLine("2. View Last Transaction");
                Console.WriteLine("3. Calculate Profit/Loss");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your option: ");

                string option = Console.ReadLine();
                Console.WriteLine();

                switch (option)
                {
                    case "1":
                        service.CreateTransaction();
                        break;

                    case "2":
                        service.ViewTransaction();
                        break;

                    case "3":
                        service.Recalculate();
                        break;

                    case "4":
                        running = false;
                        Console.WriteLine("Thank you. Application closed normally.");
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        Console.WriteLine();
                        break;
                }
            }
        }
    }
}
