using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using scratch.Models;
namespace scratch.ViewModel
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genre { get; set; }
        public Movie Movie { get; set; }
    }
}