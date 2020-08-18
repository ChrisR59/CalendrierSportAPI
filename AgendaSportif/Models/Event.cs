using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaSportif.Models
{
    public class Event
    {
        private int id;
        private string title;
        private DateTime dateEvent;

        public int Id { get => id; set => id = value; }
        public string Title { get => title; set => title = value; }
        public DateTime DateEvent { get => dateEvent; set => dateEvent = value; }
    }
}
