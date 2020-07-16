using _07_Repository_Pattern_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_StreamingContent_Inheritence
{
    public class Episode
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public double Runtime { get; set; }
        public int SeasonNumber { get; set; }

    }
    public class Show : StreamingContent
    {
        public List<Episode> Episodes { get; set; } 
        public int SeasonCount { get; set; }
        public int EpisodeCount { get; set; }
        public double AverageRuntime { get; set; }
    }
}
