using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTheater.Domain.Entities
{
    public class Seat
    {
        public bool Taken { get; set; }
        public int Price { get; set; }
        public int Row { get; set; }
        public int SeatNumber { get; set; }

        public Seat(int row, int seatNumber, int price)
        {
            Row = row;
            SeatNumber = seatNumber;
            Price = price;
        }
    }
}
