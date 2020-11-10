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
        private string type;
        private string start;
        private string end;

        public int Id { get => id; set => id = value; }
        public string Title { get => title; set => title = value; }
        public string Type { get => type; set => type = value; }
        public string Start { get => start; set => start = value; }
        public string End { get => end; set => end = value; }
    }
}
