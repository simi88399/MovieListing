using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieList.Models
{
    public class MovieListModel
    {
        private static List<MovieListModel> instance = null;
        public static List<MovieListModel> GetInstance
        {
            get
            {
                if (instance == null)
                    instance = new List<MovieListModel>();
                return instance;
            }
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
    }
}