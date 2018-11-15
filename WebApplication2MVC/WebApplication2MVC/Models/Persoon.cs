using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2MVC.Models
{
    public class Persoon
    {

        public Persoon (string naam, string email) {
            Voornaam = naam;
            Email = email;
            }
        public string Email
        {
            get;
            private set;
        }

        public string Voornaam
        {
            get;
            private set;
        }
   


    }
}
