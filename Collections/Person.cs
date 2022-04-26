using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Skillbox
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

	public class Phones
	{
		public int MobilePhone { get; set; }
		public int FlatPhone { get; set; }

		public Phones()
		{ }

		public Phones(int mobilePhone, int flatPhone)
        {
            MobilePhone = mobilePhone;
            FlatPhone = flatPhone;
        }
    }

	public class Person
	{
		public string Name { get; set; }
		public Address Address { get; set; }
		public Phones Phones { get; set; }

		public Person()
		{ }

		public Person(Address address, Phones phones, string name)
        {
            Address = address;
            Phones = phones;
            Name = name;
        }
    }

	public class NotebookList
	{
		public List<Person> Notebook { get; set; }
	}
}
