using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Skillbox.Notebook
{
	public class Address
	{
		public string Street { get; set; }
		public int HouseNumber { get; set; }
		public int FlatNumber { get; set; }

		public Address()
		{ }

		public Address(string street, int houseNumber, int flatNumber)
        {
            Street = street;
            HouseNumber = houseNumber;
            FlatNumber = flatNumber;
        }
    }
}
