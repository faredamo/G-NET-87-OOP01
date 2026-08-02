#region Task 3
using System;
using System;

DeliveryAddress address1 = new DeliveryAddress("Cairo", "Tahrir St", 10);
DeliveryAddress address2 = address1;

address2.City = "Alexandria";
address2.BuildingNumber = 99;

Console.WriteLine(address1.GetFullAddress());
Console.WriteLine(address2.GetFullAddress());
Console.WriteLine("------------------");
Shipment ship1 = new Shipment("TR101");
Shipment ship2 = new Shipment("TR102", "Laptop",2.5, 100.0m, address1);

ship1.UpdateDeliveryFee(75.0m);
ship2.Weight = -10;
ship1.PrintShipment();
Console.WriteLine("-------------------");
ship2.PrintShipment();

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

    public Shipment(string trackingCode)
    {
        this.trackingCode = "";
        this.description = "";
        this.weight = 1;
        this.deliveryFee = 1;

        TrackingCode = trackingCode;
        Description = "Unknown";
        Weight = 1;
        DeliveryFee = 50;
        Destination = new DeliveryAddress("Default City", "Default Street", 1);
    }

    public Shipment(string trackingCode, string description, double weight, decimal deliveryFee, DeliveryAddress destination)
    {
        this.trackingCode = "";
        this.description = "";
        this.weight = 1;
        this.deliveryFee = 1;

        TrackingCode = trackingCode;
        Description = description;
        Weight = weight;
        DeliveryFee = deliveryFee;
        Destination = destination;
    }

    public void UpdateDeliveryFee(decimal newFee)
    {
        if (newFee > 0)
        {
            deliveryFee = newFee;
        }
    }

    public void PrintShipment()
    {
        Console.WriteLine("Tracking Code: " + TrackingCode);
        Console.WriteLine("Description: " + Description);
        Console.WriteLine("Weight: " + Weight);
        Console.WriteLine("Delivery Fee: " + DeliveryFee);
        Console.WriteLine("Destination: " + Destination.GetFullAddress());
        Console.WriteLine("Estimated Cost: " + EstimatedCost);
    }
}