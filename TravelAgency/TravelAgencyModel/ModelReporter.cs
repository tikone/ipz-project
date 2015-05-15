﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Globalization;

namespace TravelAgencyModel
{
	public class ModelReporter
	{
		public ModelReporter( TextWriter _output, TravelAgency _travelAgency )
		{
			output = _output;
			travelAgency = _travelAgency;
		}

		public void generate()
		{
			travelAgency.forEachCustomer(showCustomer);
		}

		private void showCustomer( Customer _customer )
		{
			output.WriteLine( "==== Customers ====" );
			output.WriteLine( "Name: " + _customer.Name );
			output.WriteLine( "Surname: " + _customer.Surname );

			if (_customer.IsRegistered()) 
				showAccount(_customer.Account);
		}

		private void showAccount( Account _account )
		{
			output.WriteLine();
			output.WriteLine( "===Account Information===" );
			output.WriteLine( "ID: " + _account.ID );
			output.WriteLine( "Login: " + _account.Login );
			output.WriteLine( "Mail: " + _account.Mail );
			output.WriteLine( "Password hash: " + _account.PasswordHash );

			_account.forEachTour(showOrderedTours);
		}

		private void showOrderedTours( Tour _tour )
		{
			output.WriteLine();
			output.WriteLine("===Tour Information===");
			output.WriteLine("TourDescription: " + _tour.ViewInfo() );
			output.WriteLine("AmountPeople: " + _tour.AmountPeople);
			output.WriteLine("Country: " + _tour.Country);
			output.WriteLine("Date: " + _tour.Date_Time.ToString("d", culture) );
			output.WriteLine("Price: " + _tour.Price);

			showHotel(_tour.m_hotel);

			showItems(_tour.Tickets, @"Tickets");

			showItems(_tour.Rooms, @"Rooms");
		}

		private void showHotel( Hotel _hotel)
		{
			output.WriteLine();
			output.WriteLine("===Hotel Information===");
			output.WriteLine("Name: " + _hotel.Name);
			output.WriteLine("Address: "+ _hotel.Address);
			output.WriteLine("HotelType: "+ _hotel.Type);

			foreach( var room in _hotel.Rooms )
				showRoom( room );
		}

		private void showRoom(Room _room)
		{
			output.WriteLine();
			output.WriteLine("===Room Information===");
			output.WriteLine("bed: "+ _room.BedNumber);
			output.WriteLine("BedType: "+_room.Type);
			output.WriteLine("Reserved: " +_room.Reserved);
		}

		private void showItems< _Item >( List< _Item > _items, String _itemName )
		{
			if (_items.Count == 0)
				return;

			output.WriteLine();
			output.WriteLine("==={0}===", _itemName);
			foreach (var it in _items)
				output.WriteLine(it);
		}

		private TextWriter output;
		private TravelAgency travelAgency;
		private CultureInfo culture = new CultureInfo("pt-BR");
	}
}
