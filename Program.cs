using G_NET_87_OOP01;
using System;
using static System.Runtime.InteropServices.JavaScript.JSType;
#region 1

// (a) DeliveryAddress (Struct(Value Type))
DeliveryAddress address1 = new DeliveryAddress { City = "Cairo", Street = "Nasr City" };
DeliveryAddress address2 = address1;
address2.City = "Alexandria";

// (b) Customer (Class(Reference Type))
Customer customer1 = new Customer { Name = "Fareda" };
Customer customer2 = customer1;
customer2.Name = "Ali";

#endregion

#region Types Definition (Namespace & Classes)
namespace G_NET_87_OOP01
{
    public struct DeliveryAddress
    {
        public string City;
        public string Street;
    }
    public class Customer
    {
        public string Name;
    }
}
#endregion

#region Task 2
//(a) Identify at least three problems with this design from an encapsulation perspective.
//(b) How can private fields and public properties improve this design?
//Encapsulation protects internal data from bad values
Shipment ship = new Shipment();
ship.Description = "Electronics";
ship.Weight = 5.5;
ship.DeliveryFee = 50.0m;

Console.WriteLine($"Description: {ship.Description}");
Console.WriteLine($"Weight: {ship.Weight}");
Console.WriteLine($"Fee: {ship.DeliveryFee}");

#endregion


#region Types Definition
public struct Shipment
{
    private string description;
    private double weight;
    private decimal deliveryFee;
    public string Description
    {
        get { return description; }
        set { description = value; }
    }

    public double Weight
    {
        get { return weight; }
        set
        {
            if (value >= 0)
            {
                weight = value;
            }
        }
    }

    public decimal DeliveryFee
    {
        get { return deliveryFee; }
        set
        {
            if (value >= 0)
            {
                deliveryFee = value;
            }
        }
    }
}
#endregion