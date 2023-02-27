using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Taller.Application.Cars.Queries;
using Taller.Domain;

namespace Taller.Razor.Pages;

public class CarModel
{
    public CarModel()
    {
        GuessedPrice = false;
    }

    public int Id { get;  set; }
    public string Make { get;  set; }
    public string Model { get;  set; }
    public int Year { get;  set; }
    public int Doors { get;  set; }
    public string Color { get;  set; }
    public decimal? Price { get;  set; }
    public bool GuessedPrice { get; set; }

    public static List<CarModel> ToModel(IEnumerable<Car> cars, decimal guessPrice)
    {
        List<CarModel> carsModel = new List<CarModel>();

        

        foreach (var item in cars)
        {
            var car = new CarModel
            {
                Id = item.Id,
                Make = item.Make,
                Model = item.Model,
                Year = item.Year,
                Doors = item.Doors,
                Color = item.Color
            };

            if (CorrectPrice(item, guessPrice))
            {
                car.Price = item.Price;
                car.GuessedPrice = true;
            }

            carsModel.Add(car);
        }

        return carsModel;
    }

    static bool CorrectPrice(Car car, decimal guessPrice)
    {
        if ((car.Price - 5000) < guessPrice
        && (car.Price + 5000) > guessPrice)
        {
            return true;
        }

        return false;
    }
}

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly GetCarsQuery _query;

    public IndexModel(GetCarsQuery query, ILogger<IndexModel> logger)
    {
        _query = query;
        _logger = logger;
    }

    public void OnGet()
    {
        var cars = _query.Execute();
        Cars = CarModel.ToModel(cars, Price);
    }

    public IList<CarModel> Cars { get; set; } = default!;

    [BindProperty]
    public decimal Price { get; set; } = default!;

    public async Task<IActionResult> OnPostAsync()
    {
        OnGet();
        return Page();
    }

    //public IActionResult OnPost()
    //{
    //    OnGet();
    //    return Page();
    //}
}
