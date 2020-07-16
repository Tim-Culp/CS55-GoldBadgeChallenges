using _07_Repository_Pattern_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_StreamingContent_Inheritence
{
    public class StreamingRepository : StreamingContentRepository
    {
        public Show GetShowByTitle(string title)
        {
            foreach(StreamingContent content in _contentDirectory)
            {
                if (content.Title.ToLower() == title.ToLower() && content.GetType() == typeof(Show))
                {
                    return (Show)content;
                }
            }

            return null;
        }

        public Movie GetMovieByTitle(string title)
        {
            foreach(StreamingContent content in _contentDirectory)
            {
                if (content.Title.ToLower() == title.ToLower() && content.GetType() == typeof(Movie))
                {
                    return (Movie)content;
                }
            }

            return null;
        }

        public List<Show> GetAllShows()
        {
            List<Show> shows = new List<Show>();
            foreach(StreamingContent content in _contentDirectory)
            {
                if (content is Show)
                {
                    shows.Add((Show)content);
                }
            }
            return shows;
        }

        public List<Movie> GetAllMovies()
        {
            List<Movie> movies = new List<Movie>();
            foreach (StreamingContent content in _contentDirectory)
            {
                if (content is Movie)
                {
                    movies.Add((Movie)content);
                }
            }
            return movies;
        }

        public List<Movie> GetMoviesLongerThan(double runtime)
        {
            List<Movie> movies = new List<Movie>();
            foreach (StreamingContent content in _contentDirectory)
            {
                if (content is Movie)
                {
                    Movie nMovie = (Movie)content;
                    if (nMovie.Runtime > runtime)
                    {
                        movies.Add((Movie)content);
                    }
                }
            }
            return movies;
        }

        public List<Show> GetShowsMoreThanXEpisodes(int number)
        {
            List<Show> showsGreater = new List<Show>();
            foreach (Show show in GetAllShows())
            {
                if (show.EpisodeCount > number)
                {
                    showsGreater.Add(show);
                }
            }
            return showsGreater;
        }





        public bool UpdateShow(string title, Show updatedShow)
        {
            Show old = GetShowByTitle(title);
            if (old != null)
            {
                old = updatedShow;
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool UpdateMovie(string title, Movie updatedMovie)
        {
            Movie old = GetMovieByTitle(title);
            if (old != null)
            {
                old = updatedMovie;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
