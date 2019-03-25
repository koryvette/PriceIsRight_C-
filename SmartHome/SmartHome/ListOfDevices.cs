using System;
using System.IO;
using System.Collections.Generic;

namespace SmartHome
{
    public class ListOfDevices
    {
        public string Location { get; set; }
        public string DeviceName { get; set; }
        public string DeviceType { get; set; }
        public string Brand { get; set; }
        public string Quantity { get; set; }
        public string PricePerItem { get; set; }
        public override string ToString()
        {
            return Location+"  " + DeviceName + "  " + DeviceType + "  " + Brand + "  " + Quantity + "  " + PricePerItem;
        }
    }


}
