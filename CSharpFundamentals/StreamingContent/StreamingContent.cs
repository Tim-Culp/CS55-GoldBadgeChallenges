using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace _07_Repository_Pattern_Repository
{
    public enum Genre
    {
        Horror = 1,
        Comedy,
        SciFi,
        Drama,
        Action,
        Romance,
        Documentary,
        Anime
    }
    public enum MaturityRating
    {
        G,
        PG,
        PG13,
        R,
        NC17,
        TVMA
    }
    public class StreamingContent
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public MaturityRating MaturityRating { get; set; }
        public int StarRating { get; set; }
        public bool IsFamilyFriendly {
            get
            {
                switch (MaturityRating)
                {
                    case MaturityRating.G:
                    case MaturityRating.PG:
                        return true;
                    case MaturityRating.PG13:
                    case MaturityRating.R:
                    case MaturityRating.NC17:
                    case MaturityRating.TVMA:
                    default:
                        return false;
                }
            }
        }
        public Genre Genre { get; set; }

        public StreamingContent()
        {}
        public StreamingContent(string title, string description, MaturityRating maturityRating, int starRating, Genre genre)
        {
            Title = title;
            Description = description;
            MaturityRating = maturityRating;
            StarRating = starRating;
            Genre = genre;
        }
    }
}
