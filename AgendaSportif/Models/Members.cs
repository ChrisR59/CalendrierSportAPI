﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaSportif.Models
{
    public class Members
    {
        private int id;
        private string pseudo;
        private string email;
        private string password;
        private string token;
        private List<Event> listEvents;

        public int Id { get => id; set => id = value; }
        public string Pseudo { get => pseudo; set => pseudo = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public string Token { get => token; set => token = value; }
        public List<Event> ListEvents { get => listEvents; set => listEvents = value; }
    }
}
