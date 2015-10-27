using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelAgencyModel
{
    public class Tour
    {

        #region public fields

            public Int32 TourID { get; set; }

            public String Country { get; set; }

            public virtual TourType Type { get; set; }

            public String Description { get; set; }

        #endregion
        
        #region constructors

            public Tour(
                    String _country
                ,   String _description
                ,   TourType _type
            )
            {
                if (_country.Length == 0)
                    throw new ArgumentException( "Country should be filled" );

                this.Country = _country;
                this.Description = _description;
                this.Type = _type;

            }

            protected Tour() {}

        #endregion

        #region public methods

            public String ViewInfo()
            {
                return Description;
            }

        #endregion

    }
}
