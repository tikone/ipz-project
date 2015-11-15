using System;
using System.IO;
using System.Collections.Generic;

namespace TravelAgencyConsoleClient
{
    abstract class Command
    {
        public string Name { get; private set; }

        public IEnumerable< string > SwitchNames
        {
            get { return switches.Keys; }
        }

        protected TextWriter Output
        {
            get
            {
                return output;
            }
        }

        protected Command(string _name, TextWriter _output)
        {
            if( _name.Length == 0 )
                throw new Exception("Command: empty name not allowed");

            this.Name = _name;
            this.output = _output;

            this.switches = new Dictionary< string, CommandSwitch >();
        }

        protected void AddSwitch ( CommandSwitch _sw )
        {
            if ( switches.ContainsKey( _sw.Name ) )
                throw new Exception( "Command: duplicate switch" );

            switches.Add( _sw.Name, _sw );
        }

        public CommandSwitch FindSwitch ( string _switchName )
        {
            CommandSwitch sw;
            if ( switches.TryGetValue( _switchName, out sw ) )
                return sw;
            else
                return null;
        }

        protected void ReportValues< T > ( ICollection< T > _values )
        {
            foreach ( var value in _values )
                Output.WriteLine( value );

            Output.WriteLine( string.Format( "{0} total record(s).", _values.Count ) );
        }

        abstract public void Execute ( CommandSwitchValues values );

        private TextWriter output;

        private IDictionary< string, CommandSwitch > switches;
    }
}
