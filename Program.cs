#region Task 3
using System;

DeliveryAddress address1 = new DeliveryAddress("Cairo", "Tahrir St", 10);
DeliveryAddress address2 = address1;

address2.City = "Alexandria";
address2.BuildingNumber = 99;

Console.WriteLine(address1.GetFullAddress());
Console.WriteLine(address2.GetFullAddress());

Shipment ship = new Shipment("TRK101", "Laptop", 2.5, 50.0m, address1);

ship.Weight = -10;

Console.WriteLine(ship.TrackingCode);
Console.WriteLine(ship.Description);
Console.WriteLine(ship.Weight);
Console.WriteLine(ship.DeliveryFee);
Console.WriteLine(ship.Destination.GetFullAddress());
Console.WriteLine(ship.EstimatedCost);

public struct DeliveryAddress
{
    public string City;
    public string Street;
    public int BuildingNumber;

    public DeliveryAddress(string city, string street, int buildingNumber)
    {
        City = city;
        Street = street;
        BuildingNumber = buildingNumber;
    }

    public string GetFullAddress()
    {
        return BuildingNumber + " " + Street + ", " + City;
    }
}

public struct Shipment
{
    private string trackingCode;
    private string description;
    private double weight;
    private decimal deliveryFee;

    public string TrackingCode
    {
        get { return trackingCode; }
        private set
        {
            if (string.IsNullOrWhiteSpace(value) == false)
            {
                trackingCode = value;
            }
        }
    }

    public string Description
    {
        get { return description; }
        set
        {
            if (string.IsNullOrWhiteSpace(value) == false)
            {
                description = value;
            }
        }
    }

    public double Weight
    {
        get { return weight; }
        set
        {
            if (value > 0)
            {
                weight = value;
            }
        }
    }

    public decimal DeliveryFee
    {
        get { return deliveryFee; }
        private set
        {
            if (value > 0)
            {
                deliveryFee = value;
            }
        }
    }

    public DeliveryAddress Destination { get; set; }

    public decimal EstimatedCost
    {
        get
        {
            return deliveryFee + (decimal)(weight * 5);
        }
    }

    public Shipment(string code, string desc, double w, decimal fee, DeliveryAddress address)
    {
        trackingCode = "";
        description = "";
        weight = 1;
        deliveryFee = 1;

        TrackingCode = code;
        Description = desc;
        Weight = w;
        DeliveryFee = fee;
        Destination = address;
    }
}
#endregion