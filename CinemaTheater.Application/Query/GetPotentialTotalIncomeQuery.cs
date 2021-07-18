using CinemaTheater.Application.Interface;
using CinemaTheater.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTheater.Application.Query
{
    public class GetPotentialTotalIncomeQuery : IMetric
    {
        public double Handle(ICollection<Seat> seats)
        {
            return seats.Select(s => s.Price).Sum(p => p);
        }
    }
}
