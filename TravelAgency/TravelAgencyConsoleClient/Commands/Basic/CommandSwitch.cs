using System;

namespace TravelAgencyConsoleClient
{
    class CommandSwitch
    {
        public string Name { get; private set; }

        public bool Optional { get; private set; }

        public enum ValueMode
        {
            Unexpected,
            ExpectSingle,
            ExpectMultiple
        };

        public ValueMode Mode { get; private set; }

        public CommandSwitch( string _name, ValueMode _mode, bool _optional )
        {
            if( _name.Length == 0 )
                throw new Exception("CommandSwitch: empty name not allowed");

            this.Name = _name;
            this.Mode = _mode;
            this.Optional = _optional;
        }
    }
}