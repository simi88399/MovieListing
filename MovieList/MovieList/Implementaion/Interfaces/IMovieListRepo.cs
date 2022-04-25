using MovieList.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieList.Interfaces
{
 public   interface IMovieListRepo
    {
        IEnumerable GetAll();
        MovieListModel Get(int id);
     
        bool Update(MovieListModel item);
        bool Delete(int id);
        MovieListModel Add(MovieListModel item);
      
    }
}
