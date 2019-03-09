using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome
{
    class Program
    {
        static List<ListOfDevices> _device = new List<ListOfDevices>();
        
        static void Main(string[] args)
            // import CSV initial list of items
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            DirectoryInfo directory = new DirectoryInfo(currentDirectory);
            var fileName = Path.Combine(directory.FullName, "SmartHomeInventory.csv");
            var fileContents = ReadSmartHome(fileName);


            // Display menu upon running program
            Welcome.DisplayWelcome();

            // Menu options
            int option = 0;
            while ((option = Menu.Prompt()) != 5)
            {
                switch (option)
                {
                    case 1:
                        AddDevice();
                        break;
                   // case 2:
                   //     RemoveDevice();
                        break;
                    case 3:
                        DisplayDeviceList();
                        break;
                   // case 4:
                   //     RoomSummary();

                }
            }
        }

        public static string ReadFile(string fileName)
        {
            using (var reader = new StreamReader(fileName))
            {
                return reader.ReadToEnd();
            }

        }

        public static List<ListOfDevices> ReadSmartHome(string fileName)
        {
            var smartHome = new List<ListOfDevices>();
            using (var reader = new StreamReader(fileName))
            {
                string line = "";
                reader.ReadLine();
                while((line = reader.ReadLine()) != null)
                {
                    var device = new ListOfDevices();
                    string[] values = line.Split(',');
                    device.Location = values[0];
                    device.DeviceName = values[1];
                    device.DeviceType = values[2];
                    device.Brand = values[3];
                    device.Quantity = values[4];
                    device.PricePerItem = values[5];

                    smartHome.Add(device);
                }
            }

            return smartHome;
                     
        }



        /// Displays the list of inventory.
        static void DisplayDeviceList()
        {
            Console.WriteLine("List of Devices");
            Console.WriteLine("----------");
            _device.ForEach((dev) => Console.WriteLine(dev));
            Console.WriteLine();
                        
        }

        /// Prompts user for details of new device.
        static void AddDevice()
        {
            bool done = false;
            do
            {
                string location = Welcome.Prompt("Where is the device located? ");
                string deviceName = Welcome.Prompt("What type of device are you adding? ");
                string deviceType = Welcome.Prompt("What type of device is the " + deviceName + "?  ");
                string brand = Welcome.Prompt("Who makes the " + deviceName + " ?  ");
                string quantity = Welcome.Prompt("How many" + deviceName+ " would are you adding?  ");

                _device.Add(new ListOfDevices { Location = location, DeviceName = deviceName, DeviceType = deviceType, Brand = brand, Quantity = quantity });
                done = Welcome.Prompt("Add another device? (y/n) ").ToLower() != "y";

            } while (!done);
        }
    }
}
