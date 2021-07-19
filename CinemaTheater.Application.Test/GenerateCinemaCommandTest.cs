using System;
using Xunit;
using Shouldly;
using CinemaTheater.Application.Command;

namespace CinemaTheater.Application.Test
{
    // Not all seats are equal! If the capacity is over 50 people, the front half rows cost $12, the back half cost $10. If capacity 50 or below, all cost $10
    // Receive inputs for “number of rows” and “number of seats per row” for the given cinema room.
    public class GenerateCinemaCommandTest
    {
        [Fact]
        public void CreateCinemaTest()
        {
            var cinema = new GenerateCinemaCommand().Handle(10, 10);
            cinema.ShouldNotBeNull();
            cinema.Seats.Count.ShouldBe(100);
        }
        [Fact]
        public void CreateCinemaWhenNotEvenSplitTest()
        {
            var cinema = new GenerateCinemaCommand().Handle(11, 10);
            cinema.ShouldNotBeNull();
            cinema.Seats.Count.ShouldBe(110);
            cinema.Seats[59].Price.ShouldBe(12);
            cinema.Seats[60].Price.ShouldBe(10);
        }

        [Fact]
        public void CreateCinemaOver50CapacityTest()
        {
            var cinema = new GenerateCinemaCommand().Handle(10, 10);
            cinema.ShouldNotBeNull();
            cinema.Seats[0].Price.ShouldBe(12);
            cinema.Seats[49].Price.ShouldBe(12);
            cinema.Seats[50].Price.ShouldBe(10);
        }
        [Fact]
        public void CreateCinemaUnder49CapacityTest()
        {
            var cinema = new GenerateCinemaCommand().Handle(10, 5);
            cinema.ShouldNotBeNull();
            cinema.Seats[0].Price.ShouldBe(10);
            cinema.Seats[49].Price.ShouldBe(10);
        }
        [Fact]
        public void TryCreateCinemaWithWrongRowInputTest()
        {
            var cinema = new GenerateCinemaCommand();
            Should.Throw<ArgumentOutOfRangeException>(() => cinema.Handle(0, 10)).Message.ShouldBe("Parameter less then 1 (Parameter 'numberOfRows')");
        }
        [Fact]
        public void TryCreateCinemaWithWrongSeatInputTest()
        {
            var cinema = new GenerateCinemaCommand();
            Should.Throw<ArgumentOutOfRangeException>(() => cinema.Handle(10, 0)).Message.ShouldBe("Parameter less then 1 (Parameter 'seatsPerRow')");
        }
    }
}
