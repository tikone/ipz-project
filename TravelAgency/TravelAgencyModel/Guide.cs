using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelAgencyModel
{
    public class Guide
    {

        #region public fields

            public String Name { get; private set; }

            public HashSet< String > Languages { get; private set; }

            public Boolean Available { get; set; }

            public Int32 Phone { get; private set; }

        #endregion

        #region constructors

            public Guide(
                    String _name
                ,   String _lanuage
                ,   Int32 _phone
            )
            {
                this.Name = _name;
                this.Phone = _phone;

                this.Available = true;

                this.Languages = new HashSet<string>();
                Languages.Add(_lanuage);
            }

            public Guide(
                    String _name
                ,   HashSet<String> _lanuage
                ,   Int32 _phone
            )
            {
                this.Name = _name;
                this.Phone = _phone;

                this.Languages = _lanuage;
            }

            private Guide() { }

        #endregion

        #region public methods

            public void AddLanguage( String _language )
            {
                if( Languages.Contains( _language ) )
                    throw new Exception( @"not unique language of Guide." );

                Languages.Add( _language );

            }

        #endregion

    }
}
