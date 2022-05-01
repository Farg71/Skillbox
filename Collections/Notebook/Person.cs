using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Skillbox.Notebook
{
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
}
