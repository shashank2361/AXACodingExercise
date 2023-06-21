using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AXACodingExercise.BLL
{
    public interface ICityResult
    {
        ICollection<char> NextLetters { get; set; }
        ICollection<string> NextCities { get; set; }
    }
}
