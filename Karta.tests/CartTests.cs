using Kata;
using Kata.Interfaces;
namespace Karta.tests;

public class CartTests
{
      private ICart _shoppingCart;

        [SetUp]
        public void SetUpShoppingCart()
        {
            _shoppingCart = new Cart(new PriceCalculator());
        }

        [Test]
        public void ensure_one_item_can_be_Added_to_cart()
        {
            _shoppingCart.AddItem("A99");
            Assert.That(_shoppingCart.toalItems(), Is.EqualTo(1));
        }

        [TestCase("A99", 50)]
        [TestCase("B15", 30)]
        [TestCase("C40", 60)]
        [TestCase("T34", 99)]
        public void ensure_one_of_each_item_costs_right(string item, decimal priceExpected)
        {
            _shoppingCart.AddItem(item);

            Assert.That(_shoppingCart.totalCost(), Is.EqualTo(priceExpected));
        }

        [Test]
        public void ensure_three_a99_costs_right()
        {
            _shoppingCart.AddItem("A99");
            _shoppingCart.AddItem("A99");
            _shoppingCart.AddItem("A99");

            Assert.That(_shoppingCart.toalItems(), Is.EqualTo(3));
            Assert.That(_shoppingCart.totalCost(), Is.EqualTo(130));
        }

        [Test]
        public void ensure_two_b15_costs_right()
        {
            _shoppingCart.AddItem("B15");
            _shoppingCart.AddItem("B15");

            Assert.That(_shoppingCart.toalItems(), Is.EqualTo(2));
            Assert.That(_shoppingCart.totalCost(), Is.EqualTo(45));
        }

        [Test]
        public void ensure_one_of_each_item_subtotals_right()
        {
            _shoppingCart.AddItem("A99");
            _shoppingCart.AddItem("B15");
            _shoppingCart.AddItem("C40");

            Assert.That(_shoppingCart.toalItems(), Is.EqualTo(4));
            Assert.That(_shoppingCart.totalCost(), Is.EqualTo(239));
        }

        [TestCase("B15", 4, 90)]
        [TestCase("B15", 5, 120)]
        public void ensure_right_discounts_are_AddItemed_for_multiple_items_of_same_item(string item, int quantity,
            decimal priceExpected)
        {
            var itemCalculator = new PriceCalculator();
            Assert.That(itemCalculator.CalculatePrice(item, quantity), Is.EqualTo(priceExpected));
        }
}