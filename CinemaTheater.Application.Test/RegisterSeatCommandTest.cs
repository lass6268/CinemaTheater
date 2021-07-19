using CinemaTheater.Application.Command;
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
            seats = new List<Seat>()
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
