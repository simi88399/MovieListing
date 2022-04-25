using MovieList.Interfaces;
using MovieList.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieList.Implementaion.Repository
{
    public class MovieListRepository : IMovieListRepo
    {
        private List<MovieListModel> movieListModels;
        private int _nextId = 1;

        public MovieListRepository()
        {

            this.movieListModels = MovieListModel.GetInstance;

        }
        public MovieListModel Add(MovieListModel item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

          
            item.Id = _nextId++;
            movieListModels.Add(item);

            return item;
        }

        public IEnumerable GetAll()
        {

           
            return movieListModels;

        }

        public MovieListModel Get(int id)
        {
         
            return movieListModels.Find(p => p.Id == id);

        }

      

        public bool Update(MovieListModel item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

       
            int index = movieListModels.FindIndex(p => p.Id == item.Id);
            if (index == -1)
            {
                return false;
            }
            movieListModels.RemoveAt(index);
            movieListModels.Add(item);

            return true;
        }

        public bool Delete(int id)
        {
           //var data = movieListModels.SingleOrDefault(p => p.Id == id).IsDeleted=true;
            
            movieListModels.RemoveAll(p => p.Id == id);

            return true;
        }

    }
}