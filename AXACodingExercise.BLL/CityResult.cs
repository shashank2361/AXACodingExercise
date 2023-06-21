using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AXACodingExercise.BLL
{
    public class CityResult : ICityResult
    {
        public ICollection<char> NextLetters { get; set; }
        public ICollection<string> NextCities { get; set; }

        public CityResult()
        {
            NextLetters = new List<char>();
            NextCities = new List<string>();
        }
       
    }
}
