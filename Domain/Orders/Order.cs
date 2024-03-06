using Flunt.Validations;

namespace IWantApp.Domain.Orders;

public class Order : Entity
{
    public string ClientId { get; private set; }
    public List<Product> Products { get; private set; }
    public decimal Total { get; private set; }
    public string DeliveryAddress { get; private set; }

    private Order() { }
    private Order(string clientId, string clientName, List<Product> products, decimal total, string deliveryAddress)
    {
        ClientId = clientId;
        Products = products;
        DeliveryAddress = deliveryAddress;
        Createdby = clientName;
        EditedBy = clientName;
        CreatedOn = DateTime.UtcNow;
        EditedOn= DateTime.UtcNow;

        Total = 0;
        foreach (var item in Products)
        {
            Total += item.Price;
        }

        Validate();
    }

    private void Validate()
    {
        var contract = new Contract<Order>()
            .IsNotNull(ClientId, "Client", "Category Not Found")
            .IsNotNull(Products, "Products", "Category Not Found");
        AddNotifications(contract);
    }
}
