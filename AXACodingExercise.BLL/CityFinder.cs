using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AXACodingExercise.BLL
{
    public class CityFinder : ICityFinder
    {
        private ICollection<string> cities;

        public CityFinder(ICollection<string> cities)
        {
            this.cities = cities;
        }

        public ICityResult Search(string searchString)
        {
           ICityResult result = new CityResult();
            HashSet<char> nextLetters = new HashSet<char>();

            // Filter cities that start with the search string
            IEnumerable<string> matchedCities = SearchHelper.FindPartialMatchingStrings(cities, searchString);
            foreach (string city in matchedCities)
            {
                if (city.Length > searchString.Length)
                {
                    char nextChar = city[searchString.Length];
                    nextLetters.Add(nextChar );
                }

                result.NextCities.Add(city);
            }

            result.NextLetters = nextLetters.OrderBy(letter => letter).ToList() ;
            return result;
        }        
    }
}
 
