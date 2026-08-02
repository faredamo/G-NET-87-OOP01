using G_NET_87_OOP01;
using System;
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