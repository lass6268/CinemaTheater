using CinemaTheater.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTheater.Application.Test.Helpers
{
    public static class SeatList
    {
        public static ICollection<Seat> GetSeats()
        {
            return new List<Seat>()
            {
                new Seat(1,1,10),
                new Seat(1,2,10),
                new Seat(1,3,10)
                {Taken = true },
                new Seat(1,4,10),
                new Seat(1,3,12)
                {Taken = true },
            };
        }
    }
}
