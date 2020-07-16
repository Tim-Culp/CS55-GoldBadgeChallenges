using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace _07_Repository_Pattern_Repository
{
    public class StreamingContentRepository
    {
        protected readonly List<StreamingContent> _contentDirectory = new List<StreamingContent>();

        //create
        public bool AddContentToDirectory(StreamingContent content)
        {
            int startingCount = _contentDirectory.Count;
            _contentDirectory.Add(content);
            return startingCount < _contentDirectory.Count;
        }

        //read
        public StreamingContent GetContentByTitle(string title)
        {
            foreach (StreamingContent item in _contentDirectory)
            {
                if (item.Title.ToLower() == title.ToLower())
                {
                    return item;
                }
            }
            return null;
        }

        public List<StreamingContent> ReadContentDirectory()
        {
            return _contentDirectory;
        }

        public bool UpdateStreamingContent(string title, StreamingContent newContent)
        {
            StreamingContent old = GetContentByTitle(title);
            if (old != null)
            {
                old.Title = newContent.Title;
                old.Description = newContent.Description;
                old.MaturityRating = newContent.MaturityRating;
                old.StarRating = newContent.StarRating;
                old.Genre = newContent.Genre;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteStreamingContent(string title)
        {
            StreamingContent content = GetContentByTitle(title);
            return _contentDirectory.Remove(content);
        }

        public bool DeleteStreamingContent(StreamingContent content)
        {
            return _contentDirectory.Remove(content);
        }

        public List<StreamingContent> GetByMaturityRating(MaturityRating rating)
        {
            List<StreamingContent> returned = new List<StreamingContent>();
            foreach(StreamingContent item in _contentDirectory)
            {
                if (item.MaturityRating == rating)
                {
                    returned.Add(item);
                }
            }
            return returned;
        }
    }
}
