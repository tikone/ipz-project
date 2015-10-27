using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelAgencyModel
{
    public class Room
    {

        #region public fields

            public Int32 Number { get; private set; }

            public Int32 BedNumber { get; private set; }

            public Boolean Reserved { get; set; }

            public BedType TypeOfBeds { get; private set; }

            public RoomType TypeOfRoom { get; private set; }

        #endregion

        public Room(
                Int32 _number
            ,   Int32 _bedNumber
            ,   BedType _typeOfBed
            ,   RoomType _typeOfRoom
        )
        {
            this.Number = _number;
            this.BedNumber = _bedNumber;
            this.Reserved = false;
            this.TypeOfBeds = _typeOfBed;
            this.TypeOfRoom = _typeOfRoom;
        }

        protected Room() { }

        #region override

        public override string ToString()
        {
            var builder = new StringBuilder();

            String sep = @"  ";
            builder.Append(@"number - ");
            builder.Append(this.Number);
            builder.Append(@"bed number - ");
            builder.Append(this.BedNumber);
            builder.Append(sep);
            builder.Append(@"reserved - ");
            builder.Append(this.Reserved);
            builder.Append(sep);
            builder.Append(@"typeBed- ");
            builder.Append(this.TypeOfRoom);
            builder.Append(@"typeRoom - ");
            builder.Append(this.TypeOfRoom);

            return builder.ToString();
        }

        #endregion

    }
}
