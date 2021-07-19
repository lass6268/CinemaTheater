using CinemaTheater.Application.Query;
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
            seats = new List<Seat>()
            {
                new Seat(1,1,10),
                new Seat(1,2,10),
                new Seat(1,3,10)
                {Taken = true },
                new Seat(1,4,10)
            };
        }
        [Fact]
        public void PercentageOccupiedTest()
        {
            var percentageOccupied = new GetPercentageOccupiedQuery().Handle(seats);
            percentageOccupied.ShouldBe(25);
        }
    }
}
