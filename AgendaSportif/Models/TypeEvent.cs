﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaSportif.Models
{
    public class TypeEvent
    {
        private int id;
        private string type;

        public int Id { get => id; set => id = value; }
        public string Type { get => type; set => type = value; }
    }
}