using CinemaTheater.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTheater.Application.Command
{
    public class GenerateCinemaCommand
    {
        public Cinema Handle(int numberOfRows, int seatsPerRow)
        {
            var seats = new List<Seat>();
            if (numberOfRows*seatsPerRow > 50)
            {
                int middle = (int)(numberOfRows % 2 == 0 ? numberOfRows / 2 : Math.Ceiling((double)numberOfRows / (double)2));
                seats.AddRange(GenerateSeats(middle, seatsPerRow, 12, 1));
                seats.AddRange(GenerateSeats(numberOfRows - middle, seatsPerRow, 10, ++middle));
            }
            else
            {
                seats.AddRange(GenerateSeats(numberOfRows, seatsPerRow, 10, 1));
            }
           //Send to DB?

            return new Cinema(seats, numberOfRows, seatsPerRow);
           
        }

        private ICollection<Seat> GenerateSeats(int numberOfRows, int seatsPerRow, int price, int rowStart)
        {
            var seats = new List<Seat>();
            for (int row = rowStart; row < rowStart+numberOfRows; row++)
            {
                for (int seat = 1; seat <= seatsPerRow; seat++)
                {
                    seats.Add(
                        new Seat(row, seat, price)
                        );
                }
            }
            return seats;
        }
    }
}
