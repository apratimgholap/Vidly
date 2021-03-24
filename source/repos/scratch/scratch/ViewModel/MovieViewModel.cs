using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using scratch.Models;

namespace scratch.ViewModel
{

    //this models are not needed if we use enumerable interface or use database for customer we have used database and for movie we use enumerable in next commit we won't find this as this viewModel classes are redundant
    public class MovieViewModel
    {
        public List<Movie> movieList { get; set; }
    }
}