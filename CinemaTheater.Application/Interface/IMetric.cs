using CinemaTheater.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTheater.Application.Interface
{
    public interface IMetric
    {
        public double Handle(ICollection<Seat> seats);
    }
}
