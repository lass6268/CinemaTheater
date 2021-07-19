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
    public class GetPotentialTotalIncomeQueryTest
    {
        private static ICollection<Seat> seats { get; set; }
        public GetPotentialTotalIncomeQueryTest()
        {
            seats = SeatList.GetSeats();
        }
        [Fact]
        public void PercentageOccupiedTest()
        {
            var potentialIncome = new GetPotentialTotalIncomeQuery().Handle(seats);
            potentialIncome.ShouldBe(52);
        }
    }
}
