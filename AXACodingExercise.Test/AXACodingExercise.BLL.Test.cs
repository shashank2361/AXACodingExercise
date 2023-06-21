using AXACodingExercise.BLL;
using System.Linq;

namespace AXACodingExercise.Test
{
    public class Tests
    {
        private List<string> cities;

        [SetUp]
        public void Setup()
        {
            cities = new List<string> { "BANDUNG", "BANGUI", "BANGKOK", "BANGALORE", "LA PAZ",
                                         "LA PLATA", "LAGOS", "LEEDS", "ZARIA", "ZHUGHAI", "ZIBO" , };
        }

        [TestCase("BANG")]
        public void Given_the_input_BANG_has_matching_records_It_should_return_list_of_matching_strings(string searchString)
        {
           var expectedResult = new List<string>() { "BANGUI","BANGKOK","BANGALORE"};
           var expectedCharacter = new List<char>() {'U','K','A'};
           ICityFinder cityFinder = new CityFinder(cities);
           ICityResult searchResult = cityFinder.Search(searchString);
           Assert.That(expectedResult.Count ,Is.EqualTo( searchResult.NextCities.Count ));
           CollectionAssert.AreEqual(expectedResult.OrderByDescending(x => x),
                                searchResult.NextCities.OrderByDescending( x => x));
           Assert.That(expectedCharacter.Count, Is.EqualTo(searchResult.NextLetters.Count));
           CollectionAssert.AreEqual(expectedCharacter.OrderByDescending(x => x),
                                searchResult.NextLetters.OrderByDescending(x => x));
        }

        [TestCase("LA")]
        public void Given_the_input_LA_has_matching_records_It_should_return_list_of_matching_strings(string searchString)
        {   
            var expectedResult = new List<string>() { "LA PAZ", "LA PLATA", "LAGOS"  };
            var expectedCharacter = new List<char>() { ' ', 'G' };
            ICityFinder cityFinder = new CityFinder(cities);
            ICityResult searchResult = cityFinder.Search(searchString);
            Assert.That(expectedResult.Count, Is.EqualTo(searchResult.NextCities.Count));
            CollectionAssert.AreEqual(expectedResult.OrderByDescending(x => x),
                                 searchResult.NextCities.OrderByDescending(x => x));
            Assert.That(expectedCharacter.Count, Is.EqualTo(searchResult.NextLetters.Count));
            CollectionAssert.AreEqual(expectedCharacter.OrderByDescending(x => x),
                                searchResult.NextLetters.OrderByDescending(x => x));
        }

        [TestCase("ZE")]
        public void Given_the_input_ZE_doesnot_has_matching_records_It_should_not_return_no_results(string searchString)
        {
            ICityFinder cityFinder = new CityFinder(cities);
            ICityResult searchResult = cityFinder.Search(searchString);
            Assert.That(0, Is.EqualTo(searchResult.NextCities.Count));
            Assert.That(0, Is.EqualTo(searchResult.NextLetters.Count));
        }
    }
}