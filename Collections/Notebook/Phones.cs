using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Skillbox.Notebook
{
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
}
