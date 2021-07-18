using CinemaTheater.Application.Interface;
using CinemaTheater.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTheater.Application.Query
{
    public class GetPurchasedTicketNumbersQuery : IMetric
    {
        public double Handle(ICollection<Seat> seats)
        {
            return seats.Where(s => s.Taken == true).Count();
        }     
    }
}
