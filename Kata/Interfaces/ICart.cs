namespace Kata.Interfaces;

public interface ICart
{
    void AddItem(string item);
    int toalItems();
    decimal totalCost();
    
}