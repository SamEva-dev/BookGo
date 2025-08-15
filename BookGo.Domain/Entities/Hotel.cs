namespace BookGo.Domain.Entities;

public sealed class Hotel
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Name { get; private set; }
    public string City { get; private set; }
    public decimal NightPrice { get; private set; }
    public string Currency { get; private set; } = "EUR";
    public bool EcoLabeled { get; private set; }

    private Hotel() { }
    public Hotel(string name, string city, decimal nightPrice, bool ecoLabeled, string currency = "EUR")
    {
        Name = name;
        City = city;
        NightPrice = nightPrice;
        EcoLabeled = ecoLabeled;
        Currency = currency;
    }
}