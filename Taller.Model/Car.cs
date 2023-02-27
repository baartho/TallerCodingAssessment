namespace Taller.Domain;

public class Car
{
    public Car(int id, string make, string model, int year, int doors, string color, decimal price)
    {
        Id = id;
        Make = make;
        Model = model;
        Year = year;
        Doors = doors;
        Color = color;
        Price = price;
    }

    public int Id { get; private set; }
    public string Make { get; private set; }
    public string Model { get; private set; }
    public int Year { get; private set; }
    private int _doors;


    public int Doors
    {
        get => _doors; private set
        {
            if (value < 0)
            {
                throw new ArgumentException("Number of doors must be equals or higher than 0.");
            }
            _doors = value;
        }
    }
    public string Color { get; private set; }
    private decimal _price;
    public decimal Price
    {
        get => _price; private set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Price must be higher than 0.");
            }
            _price = value;
        }
    }


}