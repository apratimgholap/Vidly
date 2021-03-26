using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using scratch.Models;

namespace scratch.ViewModel


    // what we are essentially doing in ViewModel is encapsulating Data required by 'new action'/or new View
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; } //read-only and provides iteration over any collection type
        public Customer Customer { get; set; }
    }
}