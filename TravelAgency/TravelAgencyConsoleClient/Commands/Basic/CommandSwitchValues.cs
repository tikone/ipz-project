using System;
using System.Collections.Generic;
using System.Linq;

namespace TravelAgencyConsoleClient
{
    class CommandSwitchValues
    {
        public CommandSwitchValues()
        {
            this.values = new Dictionary< string, string >();
        }

        public bool HasSwitch( string _switchName )
        {
            return values.ContainsKey( _switchName );
        }

        public void SetSwitch( string _switchName, string _switchValue )
        {
            values.Add( _switchName, _switchValue );
        }

        public void AppendSwitch( string _switchName, string _switchValue )
        {
            string existingValue;
            if( values.TryGetValue( _switchName, out existingValue ) )
            {
                string extendedValue = existingValue + ' ' + _switchValue;
                values.Remove( _switchName );
                values.Add( _switchName, extendedValue);
            }
            else
                values.Add( _switchName, _switchValue );
        }

        public string GetSwitch( string _switchName )
        {
            string switchValue;
            if( values.TryGetValue( _switchName, out switchValue ) )
                return switchValue;

            throw new Exception("Switch " + _switchName + " was not specified.");
        }

        public int GetSwitchAsInt( string _switchName )
        {
            string switchValue = GetSwitch( _switchName );

            int result;
            if( Int32.TryParse(switchValue, out result) )
                return result;

            throw new Exception( "Switch " + _switchName + " must have an integer value." );
        }

        public double GetSwitchAsDouble( string _switchName )
        {
            string switchValue = GetSwitch( _switchName );

            double result;
            if( Double.TryParse( switchValue, out result ) )
                return result;

            throw new Exception( "Switch " + _switchName + " must have a real value." );
        }

        public decimal GetSwitchAsDecimal( string _switchName )
        {
            string switchValue = GetSwitch( _switchName );

            decimal result;
            if( Decimal.TryParse( switchValue, out result ) )
                return result;

            throw new Exception( "Switch " + _switchName + " must have a decimal value." );
        }

        public bool GetSwitchAsBool( string _switchName )
        {
            string switchValue = GetSwitch( _switchName );

            bool result;
            if( Boolean.TryParse( switchValue, out result ) )
                return result;

            throw new Exception( "Switch " + _switchName + " must have a value 'true' or 'false'." );
        }

        public string GetOptionalSwitch( string _switchName )
        {
            string switchValue;
            if( values.TryGetValue( _switchName, out switchValue ) )
                return switchValue;

            return null;
        }

        private IDictionary< string, string > values;
    }
}
