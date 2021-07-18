using CinemaTheater.Application.Command;
using CinemaTheater.Application.Interface;
using CinemaTheater.Application.Query;
using CinemaTheater.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTheater
{
    public class CinemaUI
    {
        public Dictionary<bool,char> TakenDict { get; set; }
        public StringBuilder stringBuilder { get; set; }
        public IMetric _getCurrentIncomeQuery { get; set; }
        public CinemaUI( )
        {
            stringBuilder = new StringBuilder();
            TakenDict = new Dictionary<bool, char>() {
                { true, 'R' },
                { false, 'A'}
            };
        }
        public void Show(Cinema cinema)
        {
            Console.Clear();
            stringBuilder.Clear();
            var seatIndexs = 0;
            var rowIndex = 1;
            stringBuilder.AppendLine("----Theater screen---- ");
            for (int row = 0; row < cinema.Rows; row++)
            {
                stringBuilder.Append(rowIndex.ToString());
                stringBuilder.Append(rowIndex > 9 ? " " : "  ");
                for (int i = 0; i < cinema.SeatsPerRow; i++)
                {
                    stringBuilder.Append("  " + TakenDict[cinema.Seats[seatIndexs].Taken]);
                    seatIndexs++;
                }
                stringBuilder.AppendLine();
                rowIndex++;
            }
            stringBuilder.AppendLine();
            stringBuilder.Append("     ");
            for (int i = 1; i <= cinema.SeatsPerRow; i++)
            {
                stringBuilder.Append(i < 10 ? i.ToString() + "  " : i.ToString() + " ");
            }
            stringBuilder.AppendLine();
            stringBuilder.Append("---------------------------------------------------- ");
            Console.WriteLine(stringBuilder);

            ListMetrics(cinema.Seats);
            ListActions(cinema.Seats);
            Show(cinema);
        }
        private void ListMetrics(ICollection<Seat> seats)
        {
            Console.WriteLine($"Current income      : {_getCurrentIncomeQuery.Handle(seats)}");
            Console.WriteLine($"Percentage occupied : {new GetPercentageOccupiedQuery().Handle(seats)}%");
            Console.WriteLine($"Potential income    : {new GetPotentialTotalIncomeQuery().Handle(seats)}");
            Console.WriteLine($"Purchased tickets   : {new GetPurchasedTicketNumbersQuery().Handle(seats)}");
            Console.WriteLine();
        }

        private void ListActions(ICollection<Seat> seats)
        {
            Console.WriteLine("Please select action");
            int action = GetInput($"Press 0 to exit program{Environment.NewLine}Press 1 for seat reservation{Environment.NewLine}Please enter choice",0,1);
            switch (action)
            {
                case 0:
                    Environment.Exit(0);
                    break;
                case 1:
                    bool seatReserved = true;
                    do
                    {
                        int row = GetInput("Please enter row", seats.Min(s => s.Row), seats.Max(s => s.Row));
                        int seat = GetInput("Please enter seat",seats.Min(s => s.SeatNumber), seats.Max(s => s.SeatNumber));
                    
                        // remove new statment
                        seatReserved = new RegisterSeatCommand().Handle(row, seat, seats);
                        if (!seatReserved)
                        {
                            Console.WriteLine("Seat is already reserved, please try a different seat");
                        }
                    } while (!seatReserved);
                    break;
                default:
                    break;
            }
        }

        public int GetInput(string message, int min, int max)
        {
            Console.WriteLine($"{message} between {min} and {max}");
            bool correntValue = true;
            int value;
            do
            {
                string line = Console.ReadLine();
                
                if (int.TryParse(line, out value))
                {
                    if (value >= min && value <= max)
                    {
                        correntValue = false;
                    }
                    else
                    {
                        Console.WriteLine("Number was out of possible range, please try again");
                    }
                }
                else
                {
                    Console.WriteLine("Input was not a number, please try again");
                }
            } while (correntValue);
            return value;
        }
    }
    
}
