using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

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
            _device.AddRange(ReadSmartHome(fileName));
         
            // Display menu upon running program
            Welcome.DisplayWelcome();

            // Menu options
            int option = 0;
            while ((option = Menu.Prompt()) != 4)
            {
                switch (option)
                {
                    case 1:
                        AddDevice();
                        break;
                   // case 2:
                   //     RemoveDevice();
                   //     break;
                    case 2:
                        DisplayDeviceList();
                        break;

                    case 3:
                        SaveList();
                       break;

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

        /// OPTION 1 - Prompts user for details of new device.
        static void AddDevice()
        {
            bool done = false;
            do
            {
                string location = Welcome.Prompt("Where is the device located? ");
                string deviceName = Welcome.Prompt("What type of device are you adding? ");
                string deviceType = Welcome.Prompt("What type of device is the deviceType?  ");
                string brand = Welcome.Prompt("Who makes the brand of the device?  ");
                string quantity = Welcome.Prompt("How many of these devices are you adding?  ");

                _device.Add(new ListOfDevices { Location = location, DeviceName = deviceName, DeviceType = deviceType, Brand = brand, Quantity = quantity });
                done = Welcome.Prompt("Add another device? (y/n) ").ToLower() != "y";

            } while (!done);
        }

        /// OPTION 2 - Displays the list of inventory.
        static void DisplayDeviceList()
        {
            Console.WriteLine("     List of Devices     ");
            Console.WriteLine("\r\n");
            //_device.ForEach(device => Console.WriteLine("   " + device.Location + "     "+ device.DeviceName + "     " +device.DeviceType + "     "+device.Brand+ "     " +device.Quantity + "     " +device.PricePerItem));
            //Console.WriteLine();

            for (int i = 0; i < _device.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {_device[i]}");
            }
        }

        // OPTION 3 - Get summary of devices by Room
        //static void RoomSummary()
        //{
        //    var devsum =
        //        _device.GroupBy(d => _device);
        //    var sumByRoom =
        //        from s in devsum
        //        orderby s.Sum()
        //        select new { Location = s.Location, NumGadget = s.Count() };
        //    foreach(var result in devsum)
        //        Console.WriteLine(result);


            //List<ListOfDevices> dev = ListManager._device();
            //Console.WriteLine("     List of Devices     ");
            //Console.WriteLine("\r\n");
            //_device.ForEach(device => Console.WriteLine("   " + device.Location + "     " + device.DeviceName + "     " + device.DeviceType + "     " + device.Brand + "     " + device.Quantity + "     " + device.PricePerItem));
            //Console.WriteLine();
        //}

        // OPTION 3 - Export list of devices to CSV
        static void  SaveList() 
        {
            var expList = new List<ListOfDevices>();
            var writeTo = "smarthome.txt";
        
            StringBuilder sh = new StringBuilder();
            foreach (ListOfDevices device in _device)
            {
                sh.AppendLine(device.Location + "," + device.DeviceType + ", "+ device.DeviceName + ", " + device.Brand + ", " + device.Quantity + ", " + device.PricePerItem);
            }
            File.WriteAllText(writeTo, sh.ToString());
        
        }
    }
}