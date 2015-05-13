using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelAgencyModel
{
	class Room
	{
		public Int32 BedNumber { get; set; }

		public Boolean Reserved { get; set; }

		public BedType Type { get; set; }

		public Room( Int32 _bedNumber, BedType _type)
		{
			this.BedNumber = _bedNumber;
			this.Reserved = false;
			this.Type = _type;
		}
	}
}
