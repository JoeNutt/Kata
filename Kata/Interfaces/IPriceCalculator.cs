namespace Kata.Interfaces;

public interface IPriceCalculator
{
    decimal CalculatePrice(string item,int itemAmount);
}