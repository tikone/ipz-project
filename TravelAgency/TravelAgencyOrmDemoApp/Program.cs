using System;
using System.IO;
using System.Text;

using TravelAgencyModel;
using TravelAgencyOrm;

namespace TravelAgencyOrmDemoApp
{
    class Program
    {
        public static void Main( string[] args )
        {
            Program p = new Program();

            TravelAgency savedTravelAgency = new TravelAgency();

            new TestModelGenerator( savedTravelAgency );

            SaveRestoreController.Save( savedTravelAgency );

            TravelAgency restoredTravelAgency = SaveRestoreController.Restore();

            compareTravelAgency (savedTravelAgency, restoredTravelAgency );
        }

        private static void compareTravelAgency( TravelAgency _savedTravelAgency, TravelAgency _restoredTravelAgency )
        {
            String savedContent = generateModelReport( _savedTravelAgency );
            String restoredContent = generateModelReport(_restoredTravelAgency);

            Console.WriteLine( savedContent );
            Console.WriteLine( restoredContent );
            Console.WriteLine( savedContent.Equals( restoredContent ) ? "PASSED: Models match" : "FAILED: Models mismatch" );
        }

        private static String generateModelReport( TravelAgency _travelAgency )
        {
            StringWriter writer = new StringWriter( new StringBuilder() );
            ModelReporter reporter = new ModelReporter( writer, _travelAgency );
            reporter.generate();

            return writer.ToString();
        }
    }
}
