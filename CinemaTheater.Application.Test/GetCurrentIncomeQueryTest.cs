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
    public class GetCurrentIncomeQueryTest
    {
        private static ICollection<Seat> seats { get; set; }
        public GetCurrentIncomeQueryTest()
        {
            seats = SeatList.GetSeats();
        }
        [Fact]
        public void CurrentIncomeTest()
        {
            var currentIncome = new GetCurrentIncomeQuery().Handle(seats);
            currentIncome.ShouldBe(22);
        }
    }
}
