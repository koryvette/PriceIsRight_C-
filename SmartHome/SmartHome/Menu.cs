using System;

namespace SmartHome
{
    class Menu
    {
        static string[] _options = new string[]
        {
            "Add item",
            "View list",
            "Save and export list ",
            "Quit"
        };

        /// Display the menu options.
        static void Display()
        {
            for (int i = 0; i < _options.Length; i++)
            {
                Console.WriteLine($"{i + 1}) {_options[i]}");
            }
        }

        /// Displays the application menu and prompts the user for selection.
        internal static int Prompt()
        {
            bool valid = false;
            int parsedOption = 0;
            string option = string.Empty;

            Display();
            do
            {
                option = Welcome.Prompt($"Please select an option (1-{_options.Length}): ");
                bool canParse = int.TryParse(option, out parsedOption);
                valid = canParse && parsedOption > 0 && parsedOption <= 4;
                if (!valid)
                {
                    Console.WriteLine("'" + option + "' is not a valid option. Please provide a number 1-6");
                }
            }
            while (!valid);
            return parsedOption;
        }
    }
}
