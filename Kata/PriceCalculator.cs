using Kata.Interfaces;

namespace Kata;

public class PriceCalculator : IPriceCalculator
{
    public decimal CalculatePrice(string item, int itemAmount)
    {
        switch (item)
        {
                case "A99":
                return itemAmount * 50 - ((itemAmount / 3) * 20);
                case "B15":
                return itemAmount * 30 - ((itemAmount / 2) * 15);
                case "C40":
                return 60;
                case "T34":
                return 99;
                default:
                return 0;
            }
        }
    }