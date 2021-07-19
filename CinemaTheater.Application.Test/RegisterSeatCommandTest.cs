using CinemaTheater.Application.Command;
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
    public class RegisterSeatCommandTest
    {
        private static ICollection<Seat> seats { get; set; }
        public RegisterSeatCommandTest()
        {
            seats = SeatList.GetSeats();
        }
        [Fact]
        public void RegisterSeatTest()
        {
            var registered = new RegisterSeatCommand().Handle(1,1, seats);
            seats.First().Taken.ShouldBeTrue();
        }
        [Fact]
        public void RegisterTakenSeatTest()
        {
            var registered = new RegisterSeatCommand().Handle(1, 3, seats);
            seats.First().Taken.ShouldNotBe(true);
        }
    }
}
