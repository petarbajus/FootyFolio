﻿using System.Data;

namespace FootyFolio.Model
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

        public DateTime DateCreated { get; set; }
        public Guid? WalletId { get; set; }

    }

}