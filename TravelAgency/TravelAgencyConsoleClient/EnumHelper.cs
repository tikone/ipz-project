using System;

namespace TravelAgencyConsoleClient
{
    public static class EnumHelper
    {
        public static T FromInt< T >( int value )
        {
            return (T) ( (Object)value );
        }

        public static T FromString< T >( string value )
        {
            return (T) Enum.Parse( typeof(T), value, true );
        }
    }
}
