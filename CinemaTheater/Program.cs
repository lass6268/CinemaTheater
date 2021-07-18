using CinemaTheater.Application.Command;
using CinemaTheater.Application.Query;
using CinemaTheater.Core.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace CinemaTheater
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("There is no cinema, please create one");
            var cinemaUI = new CinemaUI();
            int numberOfRowsInput = cinemaUI.GetInput("Please input number of rows",1,100);
            int seatsPerRow = cinemaUI.GetInput("Please input seats per row",1,100);

            var createCinema = new GenerateCinemaCommand().Handle(numberOfRowsInput, seatsPerRow);
            cinemaUI.Show(createCinema);
                

            Console.ReadLine();
        }
    }
}
