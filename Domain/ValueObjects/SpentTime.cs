using System;

namespace TimeSheets.Domain.ValueObjects
{
    public class SpentTime : ValueObject
    {
        public int Amount { get; }
        private SpentTime() { }

        private SpentTime(int amount)
        {
            Amount = amount;
        }

        public static SpentTime FromInt(int amount)
        {
            if (amount < 0 || amount > 8)
            {
                throw new ArgumentException("amount should be betwween 1 and 8");
            }

            return new SpentTime(amount);
        }
    }
}
