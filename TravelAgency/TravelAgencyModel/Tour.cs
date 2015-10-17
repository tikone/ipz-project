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

            public TourType Type { get; set; }

        #endregion

        #region private fields

            private String m_description;

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
                this.m_description = _description;
                this.Type = _type;

            }

            private Tour() {}

        #endregion

        #region public methods

            public String ViewInfo()
            {
                return m_description;
            }

        #endregion

    }
}
