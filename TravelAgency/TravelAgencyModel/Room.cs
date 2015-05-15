using System;
using System.Text;

namespace TravelAgencyModel
{
	public class Room
	{

		#region public fields

		public Int32 BedNumber { get; private set; }

		public Boolean Reserved { get; set; }

		public BedType Type { get; private set; }

		#endregion

		public Room( Int32 _bedNumber, BedType _type )
		{
			this.BedNumber = _bedNumber;
			this.Reserved = false;
			this.Type = _type;
		}

		#region override

		public override string ToString()
		{
			var builder = new StringBuilder();

			String sep = @"  ";
			builder.Append( @"bed number - " );
			builder.Append( this.BedNumber );
			builder.Append( sep );
			builder.Append( @"reserved - " );
			builder.Append( this.Reserved );
			builder.Append( sep );
			builder.Append( @"type - " );
			builder.Append( this.Type );

			return builder.ToString();
		}

		#endregion

	}
}
