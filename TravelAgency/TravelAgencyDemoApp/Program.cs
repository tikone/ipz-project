using System;
using System.IO;

using TravelAgencyModel;

namespace TravelAgencyDemoApp
{
	class Program
	{
		static void Main(string[] args)
		{
            Program p = new Program();
            p.fillTestModel();
            p.generateModelReport();
		}

        private void fillTestModel()
        {
            //TODO: add generate model filler
        }

        private void generateModelReport()
        {
            ModelReporter reporter = new ModelReporter( Console.Out, travelAgency);
            reporter.generate();
        }

        private TravelAgency travelAgency = new TravelAgency();
	}
}
