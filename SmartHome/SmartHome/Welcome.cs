using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome
{
    class Welcome
    {
            
        /// <summary>
        /// Displays the welcome text.
        /// </summary>
        internal static void DisplayWelcome()
        {
            Console.WriteLine("Gadget Inventory");
            Console.WriteLine("Here is a list of your Smart Home Inventory");
            Console.WriteLine("---");
        }

        /// <summary>
        /// Prompts the user to provide a value.
        /// </summary>
        /// <param name="message">The message to display to the user.</param>
        /// <returns>The response from the user</returns>
        internal static string Prompt(string message)
        {
            Console.Write(message);
            string userInput = Console.ReadLine();
            Console.WriteLine();

            return userInput.Trim();
        }
    }
}

