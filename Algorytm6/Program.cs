using Algorytm6;

List<Place> places = new();
List<Travel> travels = new();

//AddStation
AddPlace("JFK", "ATL", 150);
AddPlace("ATL", "SFO", 400);
AddPlace("ORD", "LAX", 200);
AddPlace("LAX", "DFW", 80);
AddPlace("JFK", "HKG", 800);
AddPlace("ATL", "ORD", 90);
AddPlace("JFK", "LAX", 500);

//Request
MinPriceForTravel("JFK", "LAX", 3);
MinPriceForTravel("JFK", "LAX", 1);

void AddPlace(string start, string end, int price)
{
    Place startStation = CheckIsPlacInConnection(start);
    Place endStation = CheckIsPlacInConnection(end);
    startStation.Connections.Add(endStation, price);
}

Place CheckIsPlacInConnection(string name)
{
    try
    {
        return places.First(x => x.NamePlace == name);
    }
    catch
    {
        var newPlace = new Place() { NamePlace = name };
        places.Add(newPlace);
        return newPlace;
    }
}

void MinPriceForTravel(string startPlace, string endPlace, int change)
{
    travels = new();
    Place start = CheckIsPlacInConnection(startPlace);
    Place end = CheckIsPlacInConnection(endPlace);

    Travel travel = new Travel();
    Move(start, end, travel, change);

    Travel travel2 = travels.MinBy(x => x.Price);

    if (travel2 == null)
    {
        Console.WriteLine("Nie znaleziono");
        return;
    }

    Console.WriteLine($"{String.Join("->", travel2.Changes.Select(c => c.NamePlace).ToList())}");
    Console.WriteLine($"\nCena {travel2.Price}");
}

void Move(Place station, Place endStation, Travel travel, int change, int price = 0)
{
    travel.Changes.Add(station);
    travel.Price += price;

    if (station == endStation)
    {
        travels.Add(travel);
        return;
    }

    foreach (var nextStation in station.Connections) 
    {
        if (change == 0 || !travel.Changes.Contains(station))
        {
            return;
        }
        Move(nextStation.Key,endStation,new Travel(travel), change-1, nextStation.Value);
    }
}