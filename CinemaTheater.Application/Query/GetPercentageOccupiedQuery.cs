using CinemaTheater.Application.Interface;
using CinemaTheater.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTheater.Application.Query
{
    public class GetPercentageOccupiedQuery : IMetric
    {
        public double Handle(ICollection<Seat> seats)
        {
            var takenSeats = seats.Where(s => s.Taken).Count();
            return ((double)takenSeats / (double)seats.Count) * 100;
        }
    }
}
