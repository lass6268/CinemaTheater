using CinemaTheater.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTheater.Application.Command
{
    public class RegisterSeatCommand
    {
        public bool Handle(int row, int seatNumber, ICollection<Seat> seats)
        {
            var seat = seats.Where(s => s.Row == row && s.SeatNumber == seatNumber).FirstOrDefault();
            if (seat.Taken)
            {
                return false;
            }
            seat.Taken = true;
            return true;
        }
    }
}
