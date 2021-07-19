using CinemaTheater.Application.Query;
using CinemaTheater.Application.Test.Helpers;
using CinemaTheater.Domain.Entities;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CinemaTheater.Application.Test
{
    public class GetPurchasedTicketNumbersQueryTest
    {
        private static ICollection<Seat> seats { get; set; }
        public GetPurchasedTicketNumbersQueryTest()
        {
            seats = SeatList.GetSeats();
        }
        [Fact]
        public void PercentageOccupiedTest()
        {
            var percentageOccupied = new GetPurchasedTicketNumbersQuery().Handle(seats);
            percentageOccupied.ShouldBe(2);
        }
    }
}
