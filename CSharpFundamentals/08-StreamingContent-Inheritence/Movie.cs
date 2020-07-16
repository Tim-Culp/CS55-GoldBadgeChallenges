using _07_Repository_Pattern_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_StreamingContent_Inheritence
{
    public class Movie : StreamingContent
    {
        public double Runtime { get; set; }
        public Movie() { }
        public Movie(string title, string description, MaturityRating maturityRating, int starRating, Genre genre, double runtime)
        : base(title, description, maturityRating, starRating, genre)
        {
            Runtime = runtime;
        }
    }
}
