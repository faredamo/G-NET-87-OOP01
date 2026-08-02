using System;
#region 6
DeliveryAddress address1 = new DeliveryAddress("Cairo", "Tahrir St", 10);
DeliveryAddress address2 = address1;

address2.City = "Alexandria";

Console.WriteLine("Addr1: " + address1.GetFullAddress());
Console.WriteLine("Addr2: " + address2.GetFullAddress());
Console.WriteLine("--------------------------------");

DeliveryCenter center = new DeliveryCenter();

for (int i = 0; i < 3; i++)
{
    Console.WriteLine("Enter Shipment " + (i + 1) + " details:");

    Console.Write("Tracking Code: ");
    string code = Console.ReadLine();

    Console.Write("Description: ");
    string desc = Console.ReadLine();

    Console.Write("Weight: ");
    double weight = double.Parse(Console.ReadLine());

    Console.Write("Delivery Fee: ");
    decimal fee = decimal.Parse(Console.ReadLine());

    Console.Write("City: ");
    string city = Console.ReadLine();

    Console.Write("Street: ");
    string street = Console.ReadLine();

    Console.Write("Building Number: ");
    int building = int.Parse(Console.ReadLine());

    DeliveryAddress address = new DeliveryAddress(city, street, building);
    Shipment shipment = new Shipment(code, desc, weight, fee, address);

    center.AddShipment(shipment);
    Console.WriteLine("----------------------");
}
Console.WriteLine("All Shipments:");
for (int i = 0; i < 3; i++)
{
    Shipment s = center[i];
    s.PrintShipment();
    Console.WriteLine("------------------------");
}
Console.Write("Enter tracking code to search: ");
string searchCode = Console.ReadLine();

Shipment foundShipment = center[searchCode];

if (foundShipment.TrackingCode != null && foundShipment.TrackingCode != "")
{
    Console.WriteLine("Shipment Found:");
    foundShipment.PrintShipment();
}
else
{
    Console.WriteLine("Shipment not found.");
}
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
            if (value != "")
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
            if (value != "")
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
        {
            deliveryFee = newFee;
        }
    }
    public void PrintShipment()
    {
        Console.WriteLine("Code: " + TrackingCode);
        Console.WriteLine("Desc: " + Description);
        Console.WriteLine("Weight: " + Weight);
        Console.WriteLine("Fee: " + DeliveryFee);
        Console.WriteLine("Address: " + Destination.GetFullAddress());
        Console.WriteLine("Estimated Cost: " + EstimatedCost);
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
        get
        {
            if (index >= 0 && index < count)
            {
                return shipments[index];
            }
            return default;
        }
        set
        {
            if (index >= 0 && index < count)
            {
                shipments[index] = value;
            }
        }
    }

    public Shipment this[string trackingCode]
    {
        get
        {
            for (int i = 0; i < count; i++)
            {
                if (shipments[i].TrackingCode == trackingCode)
                {
                    return shipments[i];
                }
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