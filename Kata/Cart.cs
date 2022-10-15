using Kata.Interfaces;

namespace Kata;
using System.Linq;
public class Cart : ICart
{
    private readonly IPriceCalculator _priceCalculator;
    private readonly IList<string> _items; 

    public Cart(IPriceCalculator priceCalculator)
    {
        _priceCalculator = priceCalculator;
        _items = new List<string>(); 
    }

    public void AddItem(string item)
    {
       _items.Add(item);
    }

    public int toalItems()
    {
        return _items.Count;
    }

    public decimal totalCost()
    {
        var groupedItems = _items
            .GroupBy(x => x)
            .ToDictionary(item => item.Key, itemCount => itemCount.Count());
        return groupedItems.Sum(item => _priceCalculator.CalculatePrice(item.Key, item.Value));
    }
}