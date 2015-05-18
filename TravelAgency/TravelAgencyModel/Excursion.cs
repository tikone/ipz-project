using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelAgencyModel
{
    public class Excursion
    {

        #region public fields

            public String Name { get; set; }

            public Double Price { get; set; }

            public DateTime Date_Time { get; set; }

            private HashSet< Guide > m_guides;

        #endregion

        #region constructors

            public Excursion(
                    String _name
                ,   Double _price
                ,   DateTime _dateTime
            )
            {
                if( _name == null || _name == @"" )
                    throw new ArgumentNullException();

                this.Name = _name;
                this.Price = _price;
                this.Date_Time = _dateTime;

                m_guides = new HashSet< Guide >();
            }

        #endregion

        #region public methods

            public List< String > getAvailableLanguages()
            {
                HashSet< String > languages = new HashSet< String >();

                foreach( Guide guide in m_guides )
                    if( guide.Available )
                        foreach( var lan in guide.Languages.ToArray() )
                            languages.Add( lan );

                return languages.ToList();
            }

            public void addGuide( Guide _guide )
            {
                if( m_guides.Contains( _guide ) )
                    throw new Exception( @"not unique guide in one excursion." );

                m_guides.Add( _guide );
            }

            public List<Guide> getAvailableGuides()
            {
                List<Guide> guides = new List<Guide>();

                foreach (Guide guide in m_guides)
                    if (guide.Available)
                        guides.Add( guide );

                return guides.ToList();
            }

        #endregion
    }
}
