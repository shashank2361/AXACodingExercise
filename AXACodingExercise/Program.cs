// See https://aka.ms/new-console-template for more information
using AXACodingExercise.BLL;

Console.WriteLine("Hello");
//this could be from DBcontext
List<string> cities = new List<string> { "BANDUNG", "BANGUI", "BANGKOK", "BANGALORE", "LA PAZ",
                                         "LA PLATA", "LAGOS", "LEEDS", "ZARIA", "ZHUGHAI", "ZIBO" ,
                                        };
ICityFinder cityFinder = new CityFinder(cities);

string searchString = "LA";

ICityResult searchResult = cityFinder.Search(searchString);

Console.WriteLine("Next characters:");
foreach (char letter in searchResult.NextLetters)
{
    Console.WriteLine(letter);
}

Console.WriteLine("Cities:");
foreach (string city in searchResult.NextCities)
{
    Console.WriteLine(city);
}