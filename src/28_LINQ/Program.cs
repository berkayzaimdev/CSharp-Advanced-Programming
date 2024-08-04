using System.Linq;
using System.Linq.Dynamic.Core;

List<Order> orders = new List<Order>
        {
            new Order { Id = 1, Amount = 150, OrderDate = DateTime.Now.AddDays(-1) },
            new Order { Id = 2, Amount = 250, OrderDate = DateTime.Now.AddDays(-3) },
            new Order { Id = 3, Amount = 50, OrderDate = DateTime.Now.AddDays(-2) }
        };

// Dinamik filtreleme
string filterProperty = "Amount";
decimal filterValue = 100;

// Birden fazla koşul kullanımı
string filter = $"{filterProperty} > @0 AND OrderDate < @1";
object[] parameters = { filterValue, DateTime.Now.AddDays(-1) };

var filteredOrders = orders.AsQueryable()
                           .Where(filter, parameters);

// Dinamik sıralama
string sortProperty = "OrderDate";
string sortDirection = "desc";

var sortedOrders = filteredOrders
                    .OrderBy($"{sortProperty} {sortDirection}")
                    .ToList();

foreach (var order in sortedOrders)
{
    Console.WriteLine($"Order ID: {order.Id}, Amount: {order.Amount}, Order Date: {order.OrderDate}");
}

class Order
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public DateTime OrderDate { get; set; }
}