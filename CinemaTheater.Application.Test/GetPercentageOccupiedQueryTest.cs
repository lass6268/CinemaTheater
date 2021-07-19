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
    public class GetPercentageOccupiedQueryTest
    {
        private static ICollection<Seat> seats { get; set; }
        public GetPercentageOccupiedQueryTest()
        {
            seats = SeatList.GetSeats();
        }
        [Fact]
        public void PercentageOccupiedTest()
        {
            var percentageOccupied = new GetPercentageOccupiedQuery().Handle(seats);
            percentageOccupied.ShouldBe(40);
        }
    }
}
