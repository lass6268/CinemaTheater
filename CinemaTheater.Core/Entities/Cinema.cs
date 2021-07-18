using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTheater.Core.Entities
{
    public class Cinema
    {
        public int Rows { get; set; }
        public int SeatsPerRow { get; set; }
        public List<Seat> Seats { get; set; }

        public Cinema(ICollection<Seat> seats, int rows, int seatsPerRow)
        {
            Seats = seats.ToList();
            Rows = rows;
            SeatsPerRow = seatsPerRow;
        }
    }
}
