using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using scratch.Models;

namespace scratch.ViewModel
{
    public class RandomViewModel
    {

        public Movie Movie { get; set; }
        public List<Customer> Customers { get; set; }
    }
}