using System;
#region Task 5
DeliveryAddress address = new DeliveryAddress("Cairo", "Tahrir St", 10);
Shipment ship = new Shipment("TR101", "Laptop", 2.5, 100.0m, address);

DeliveryCenter center = new DeliveryCenter();
center.AddShipment(ship);

Shipment result = center["TR101"];
result.PrintShipment();
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
        get { 
               return trackingCode; }
        private set { 
            if (!string.IsNullOrWhiteSpace(value)) 
                trackingCode = value; }
    }

    public string Description
    {
        get { 
            return description; }
        set { 
            if (!string.IsNullOrWhiteSpace(value)) 
                description = value; }
    }

    public double Weight
    {
        get { 
            return weight; }
        set { 
            if (value > 0)
                weight = value; }
    }

    public decimal DeliveryFee
    {
        get { 
            return deliveryFee; }
        private set { 
            if (value > 0) 
                deliveryFee = value; }
    }

    public DeliveryAddress Destination { get; set; }

    public decimal EstimatedCost
    {
        get { return deliveryFee + (decimal)(weight * 5); }
    }

    public Shipment(string trackingCode)
    {
        this.trackingCode = trackingCode;
        description = "Unknown";
        weight = 1;
        deliveryFee = 50;
        Destination = new DeliveryAddress("Default", "Default", 1);
    }

    public Shipment(string trackingCode, string description, double weight, decimal deliveryFee, DeliveryAddress destination)
    {
        this.trackingCode = trackingCode;
        this.description = description;
        this.weight = weight;
        this.deliveryFee = deliveryFee;
        Destination = destination;
    }

    public void UpdateDeliveryFee(decimal newFee)
    {
        if (newFee > 0) 
            deliveryFee = newFee;
    }

    public void PrintShipment()
    {
        Console.WriteLine("Code:" + TrackingCode + " | Desc:" + Description + " | Cost:" + EstimatedCost);
    }
}

public struct DeliveryCenter
{
    private Shipment[] shipments;
    private int count;

    public DeliveryCenter()
    {
        shipments = new Shipment[10];
        count = 0;
    }

    public Shipment this[int index]
    {
        get { return (index >= 0 && index < count) ? 
                shipments[index] : 
                default; }
        set { if (index >= 0 && index < count) 
                shipments[index] = value; }
    }

    public Shipment this[string trackingCode]
    {
        get
        {
            for (int i = 0; i < count; i++)
            {
                if (shipments[i].TrackingCode == trackingCode) return shipments[i];
            }
            return default;
        }
    }

    public bool AddShipment(Shipment shipment)
    {
        if (count < 10)
        {
            shipments[count] = shipment;
            count++;
            return true;
        }
        return false;
    }
}
#endregion