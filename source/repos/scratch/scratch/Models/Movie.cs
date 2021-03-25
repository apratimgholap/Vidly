using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace scratch.Models
{
    public class Movie
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public Genre GenreType { get; set; }
        public byte GenreId { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime DateAdded { get; set; }
        public int NoOfStockAvailable { get; set; }
    }
}