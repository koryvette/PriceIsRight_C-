using System;

namespace SmartHome
{
    class Welcome
    {

        /// Display greeting.
        internal static void DisplayWelcome()
        {
            Console.WriteLine("Gadget Inventory");
            Console.WriteLine("Here is a list of your Smart Home Inventory");
            Console.WriteLine("---");
        }

        /// Prompts the user to provide a value.
        internal static string Prompt(string message)
        {
            Console.Write(message);
            string userInput = Console.ReadLine();
            Console.WriteLine();

            return userInput.Trim();
        }
    }
}


