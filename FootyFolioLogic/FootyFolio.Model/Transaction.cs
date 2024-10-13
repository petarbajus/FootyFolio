using System;

namespace FootyFolio.Model
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public Guid UserSellingId { get; set; } 
        public Guid UserBuyingId { get; set; }
        public Guid FootballerId { get; set; } 
        public DateTime DateCreated { get; set; }
    }
}
