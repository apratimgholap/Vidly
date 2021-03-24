using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace scratch.Models
{
    public class Customer
    {   
        [Required]
        [StringLength(255)]
        public string Name { get; set; } 
        public  int Id { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }
        public MembershipType MembershipType  { get; set; } //navigation property
        public byte MembershipTypeId { get; set; } //foreign key
        public string Birthdate { get; set; }
    }

   
}