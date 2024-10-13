using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootyFolio.Model
{
    public class Footballer
    {
        public Guid Id { get; set; }  
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Price { get; set; }
        public bool IsForSale {  get; set; }
        public Guid UserId { get; set; }
        public DateTime DateCreated { get; set; }
        public User User { get; set; }

    }
}
